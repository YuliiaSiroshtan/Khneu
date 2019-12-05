using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.JWT;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.Misc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.Mics
{
    public class TokenService : BaseService, ITokenService
    {
        private readonly ISecurityService _securityService;

        public TokenService(IUnitOfWork uow, IMapper mapper, ISecurityService securityService) : base(uow, mapper) =>
            this._securityService = securityService;

        public async Task<JwtResult> CreateJwtSecurityToken(string userName, string password)
        {
            var result = new JwtResult();

            var securityPassword = this._securityService.GetSha512Hash(password);
            var user = await this.Uow.UserRepository.GetUserByLoginAndPassword(userName, securityPassword);

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

            result.JwtToken = new JwtToken
            {
                Token = finalToken,
                Login = claimsIdentity.Name
            };

            return result;
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