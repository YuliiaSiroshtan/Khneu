﻿using Planner.Entities.JWT;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.Misc
{
    public interface ITokenService
    {
        Task<JwtResult> CreateJwtSecurityToken(string userName, string password);

        ClaimsPrincipal GetClaims(string token);
    }
}