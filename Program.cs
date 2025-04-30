using System.Text;
using DHL.Server.Components;
using Microsoft.EntityFrameworkCore;
using DHL.Server.Data;
using DHL.Server.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using MudBlazor;
using Microsoft.Extensions.FileProviders;
using AutoMapper;
using DHL.Server.Models.Profiles;
using DHL.Server.Features.Dispatching.Services;
using DHL.Server.Features.Dispatching.Interfaces;





var builder = WebApplication.CreateBuilder(args);

// Pøidání Controllerù (DÙLEŽITÉ PRO API)
builder.Services.AddControllers();

builder.Services.AddScoped<AuthenticationStateProvider, FakeAuthenticationStateProvider>();
// builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider>();

var authSettings = builder.Configuration.GetSection("Authentication").Get<AuthSettings>() ?? new AuthSettings();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-super-secret-key")) // Vývojový klíè
            };
        }
        else
        {
            options.Authority = authSettings.Authority;
            options.Audience = authSettings.Audience;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        }
    });

builder.Services.AddAuthorization();
builder.Services.AddAutoMapper(typeof(MappingProfile));



// Pøidání Razor Components + MudBlazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = true;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 300;
    config.SnackbarConfiguration.ShowTransitionDuration = 300;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled; // Možnosti: Text, Outlined, Filled
});


// Pøidání DispatchService + HttpClient
builder.Services.AddScoped<IDispatchService, DispatchService>();
// Pøidání Minimalizace css
builder.Services.AddSingleton<CssMinifierService>();


// Registrace ApplicationDbContext s SQL Serverem
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// SpuštìníMinimalizace css
using (var scope = app.Services.CreateScope())
{
    var cssMinifier = scope.ServiceProvider.GetRequiredService<CssMinifierService>();
    CssMinifierService.MinifyCss("wwwroot/font-awesome/css/all.css", "wwwroot/font-awesome/css/all.min.css");
}

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "font-awesome")),
    RequestPath = "/font-awesome"
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();

// Konfigurace pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // HSTS (pouze produkce)
}

app.UseHttpsRedirection();
app.UseAntiforgery();

// Mapování API Controllerù
app.MapControllers();

// Mapování Razor Components
app.MapRazorComponents<DHL.Server.App>()
    .AddInteractiveServerRenderMode();

app.Run();
