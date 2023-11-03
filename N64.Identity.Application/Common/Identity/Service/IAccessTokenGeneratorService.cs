using N64.Identity.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace N64.Identity.Application.Common.Identity.Service
{
    public interface IAccessTokenGeneratorService
    {
        string GetToken(User user);
        JwtSecurityToken GetJwtToken(User user);
        List<Claim> GetClaims(User user);
    }
}
