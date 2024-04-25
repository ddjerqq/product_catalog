using Application.Common.Abstractions;
using Infrastructure.Auth;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class WebHostBuilderExt
{
    public static void AddUtcDateTimeProvider(this WebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddScoped<IDateTimeProvider, UtcDateTimeProvider>();
        });
    }

    public static void AddEmailProviders(this WebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddScoped<IEmailSender, GoogleEmailSender>();
            services.AddScoped<IEmailSender, ProtonEmailSender>();
            services.AddScoped<IEmailSenderFactory, EmailSenderFactory>();
        });
    }

    public static void AddDbContext(this WebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var dbPath = Environment.GetEnvironmentVariable("DB__PATH");
                options.UseSqlite(dbPath);
            });

            services.AddScoped<IDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        });
    }

    public static void AddJwtAuth(this WebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.MapInboundClaims = false;
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.Events = Jwt.Events;

                    options.Audience = Jwt.Audience;
                    options.ClaimsIssuer = Jwt.Issuer;

                    options.TokenValidationParameters = Jwt.TokenValidationParameters;
                });
        });
    }
}