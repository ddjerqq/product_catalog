using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Common.Abstractions;
using Infrastructure.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class AuthController(IDateTimeProvider dateTimeProvider) : ControllerBase
{
    [HttpGet("claims")]
    public IActionResult GetClaims()
    {
        var claims = User.Claims
            .ToDictionary(c => c.Type, c => c.Value);

        return Ok(claims);
    }

    [AllowAnonymous]
    [HttpGet("login/{username}")]
    public IActionResult Login(string username)
    {
        List<Claim> claims =
        [
            new Claim(JwtRegisteredClaimNames.Sid, username),
        ];

        var token = Jwt.GenerateToken(claims, TimeSpan.FromDays(1), dateTimeProvider);
        Response.Cookies.Append("authorization", token, Cookie.Options);

        return Ok(token);
    }
}