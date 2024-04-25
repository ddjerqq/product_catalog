using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Application.Common.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Auth;

public static class Jwt
{
    public static readonly JwtBearerEvents Events = new()
    {
        OnMessageReceived = ctx =>
        {
            ctx.Request.Query.TryGetValue("authorization", out var query);
            ctx.Request.Headers.TryGetValue("authorization", out var header);
            ctx.Request.Cookies.TryGetValue("authorization", out var cookie);

            ctx.Token = (string?)query ?? (string?)header ?? cookie;
            return Task.CompletedTask;
        },
    };

    internal const string Issuer = "localhost";
    internal const string Audience = "localhost";

    private static SecurityKey Key
    {
        get
        {
            var rsa = RSA.Create();

            var publicKey = Environment.GetEnvironmentVariable("Jwt:PublicKey")!;
            rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);

            var privateKey = Environment.GetEnvironmentVariable("Jwt:PrivateKey")!;
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);

            return new RsaSecurityKey(rsa);
        }
    }

    internal static readonly TokenValidationParameters TokenValidationParameters = new()
    {
        ValidIssuer = Issuer,
        ValidAudience = Audience,
        IssuerSigningKey = Key,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAlgorithms = [SecurityAlgorithms.HmacSha256],
    };

    private static readonly SigningCredentials SigningCredentials = new(Key, SecurityAlgorithms.Sha256);

    public static string GenerateToken(IEnumerable<Claim> claims, TimeSpan expiration, IDateTimeProvider dateTimeProvider)
    {
        var token = new JwtSecurityToken(
            Issuer,
            Audience,
            claims,
            expires: dateTimeProvider.UtcNow.Add(expiration),
            signingCredentials: SigningCredentials);

        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(token);
    }
}