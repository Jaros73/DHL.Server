using System.Text;
using System.IO;
using DHL.Server;
using DHL.Server.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Web;
using DHL.Server.Data;
using DHL.Server.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Components;
using MudBlazor.Services;
using MudBlazor;
using Microsoft.Extensions.FileProviders;
using AutoMapper;
using DHL.Server.Models.Profiles;
using DHL.Server.Features.Dispatching.Services;
using DHL.Server.Features.Dispatching.Interfaces;
using DHL.Server.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Features.Ciselniky.Services;
using DHL.Server.Models.Entities;
using System.Globalization;

Environment.SetEnvironmentVariable("DOTNET_WATCH", "false");
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("cs-CZ");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("cs-CZ");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var authSettings = builder.Configuration.GetSection("Authentication").Get<AuthSettings>() ?? new AuthSettings();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddAuthentication("Fake")
        .AddScheme<AuthenticationSchemeOptions, FakeAuthHandler>("Fake", options => { });

    builder.Services.AddScoped<AuthenticationStateProvider, FakeAuthenticationStateProvider>();
    builder.Services.AddAuthorizationCore();
}
else
{
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
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
        });

    builder.Services.AddAuthorization();
}

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = true;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 300;
    config.SnackbarConfiguration.ShowTransitionDuration = 300;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddScoped<IDispatchService, DispatchService>();
builder.Services.AddScoped<IKlicService, CiselnikyService>();
builder.Services.AddScoped<IKurzyPEService, KurzyPEService>();
builder.Services.AddScoped<KurzyPEImportService>();
builder.Services.AddScoped<IPrepravceService, PrepravceService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IZpozdeniKurzuService, ZpozdeniKurzuService>();
builder.Services.AddScoped<IPripojVozidloService, PripojVozidloService>();
builder.Services.AddScoped<IVozidloService, VozidloService>();
builder.Services.AddScoped<IZastavkaService, ZastavkaService>();
builder.Services.AddScoped<ILocationService, LocationService>();


builder.Services.AddSingleton<CssMinifierService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await DbInitializer.InitializeAsync(db);
}


using (var scope = app.Services.CreateScope())
{
    var cssMinifier = scope.ServiceProvider.GetRequiredService<CssMinifierService>();
    CssMinifierService.MinifyCss("wwwroot/font-awesome/css/all.css", "wwwroot/font-awesome/css/all.min.css");
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

app.UseWebSockets(webSocketOptions);

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
