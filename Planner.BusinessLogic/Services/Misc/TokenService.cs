﻿using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.JWT;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.Misc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.Misc
{
    public class TokenService : BaseService, ITokenService
    {
        private readonly ISecurityService _securityService;

        public TokenService(IRepositoryScope repositoryScope, IMapper mapper, ISecurityService securityService) : base(
            repositoryScope, mapper) =>
            this._securityService = securityService;

        public async Task<JwtResult> CreateJwtSecurityToken(string userName, string password)
        {
            var result = new JwtResult();

            var securityPassword = this._securityService.GetSha512Hash(password);
            var user = await this.RepositoryScope.UserRepository.GetUserByLoginAndPassword(userName, securityPassword);

            if (user == null)
            {
                result.Error = "Invalid username or password";
                return result;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConst.KEY));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                JwtConst.ISSUER,
                JwtConst.AUDIENCE,
                claims,
                expires: DateTime.Now.AddMinutes(JwtConst.LIFETIME),
                signingCredentials: credentials);

            var finalToken = new JwtSecurityTokenHandler().WriteToken(token);

            switch (user.Role.Id)
            {
                case 2:
                    var departmentId = await this.RepositoryScope.UserRepository.GetDepartmentIdByLogin(userName);

                    result.JwtToken = new JwtToken
                    {
                        Token = finalToken,
                        Login = claimsIdentity.Name,
                        Role = user.Role.Name,
                        DepartmentId = departmentId.ToString()
                    };

                    return result;
                default:
                    result.JwtToken = new JwtToken
                    {
                        Token = finalToken,
                        Login = claimsIdentity.Name,
                        Role = user.Role.Name
                    };

                    return result;
            }
        }

        public ClaimsPrincipal GetClaims(string token)
        {
            var securityTokenHandler = new JwtSecurityTokenHandler();

            var validateParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = JwtConst.ISSUER,
                ValidateAudience = true,
                ValidAudience = JwtConst.AUDIENCE,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConst.KEY))
            };

            var claimsPrincipal = securityTokenHandler.ValidateToken(token, validateParameters, out _);

            return claimsPrincipal;
        }
    }
}