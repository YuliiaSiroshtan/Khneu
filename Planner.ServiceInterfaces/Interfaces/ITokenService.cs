using Planner.ServiceInterfaces.DTO.JWT;
using System;
using System.Security.Claims;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface ITokenService
    {
        JwtResult CreatejwtSecurityToken(String userName, String password);
        ClaimsPrincipal GetClaims(String token);
    }
}
