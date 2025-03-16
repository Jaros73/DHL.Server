using System.Text;
using DHL.Server.Components;
using Microsoft.EntityFrameworkCore;
using DHL.Server.Data;
using DHL.Server.Models;
using DHL.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using DHL.Server.Interfaces;




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

// Pøidání Razor Components + MudBlazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();

// Pøidání DispatchService + HttpClient
builder.Services.AddScoped<IDispatchService, DispatchService>();


// Registrace ApplicationDbContext s SQL Serverem
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Konfigurace pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // HSTS (pouze produkce)
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Mapování API Controllerù
app.MapControllers();

// Mapování Razor Components
app.MapRazorComponents<DHL.Server.App>()
    .AddInteractiveServerRenderMode();

app.Run();
