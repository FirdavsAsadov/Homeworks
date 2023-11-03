using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using N64.Identity.Application.Common.Constants;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Application.Common.Settings;
using N64.Identity.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class AccessTokenGeneratorService : IAccessTokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;

    public AccessTokenGeneratorService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GetToken(User user)
    {
        var jwtToken = GetJwtToken(user);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            signingCredentials: credentials);
    }

    public List<Claim> GetClaims(User user)
    {
        return new List<Claim>()
        {
            new(ClaimTypes.Email, user.Email),
            new(ClaimConstants.UserId , user.Id.ToString())
        };
    }
}
