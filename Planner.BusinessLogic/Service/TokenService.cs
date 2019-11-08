using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Planner.Entities.JWT;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _uow;
        private readonly ISecurityService _securityService;

        public TokenService(IUnitOfWork uow, ISecurityService securityService)
        {
            _uow = uow;
            _securityService = securityService;

        }

        public async Task<JwtResult> CreateJwtSecurityToken(string userName, string password)
        {
            var result = new JwtResult();

            var securityPassword = _securityService.GetSha256Hash(password);
            var user = await _uow.UserRepository.GetUserByLoginAndPassword(userName, securityPassword);

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
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: JwtConst.ISSUER,
                audience: JwtConst.AUDIENCE,
                claims: claims,
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
