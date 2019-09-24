using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Planner.Common.Constants;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.DTO.JWT;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
{
    public class TokenService : ITokenService
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private ISecurityService _securityService;

        public TokenService(IUnitOfWork uow, IMapper mapper,
            ISecurityService securityService)
        {
            _uow = uow;
            _mapper = mapper;
            _securityService = securityService;

        }

        public JwtResult CreatejwtSecurityToken(String userName, String password)
        {
            JwtResult result = new JwtResult();

            String securityPassword = _securityService.GetSha256Hash(password);
            ApplicationUser user = _uow.UserRepository.GetUser(userName, securityPassword);
            if(user == null)
            {
                result.Error = "Invalid username or password";
                return result;
            }
            if(user != null && !user.IsActive)
            {
                result.Error = "Користувач деактивованний!";
                return result;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConst.SECURITY_KEY));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                                            issuer: JwtConst.ISSUER,
                                            audience: JwtConst.AUDIENCE,
                                            claims: claims,
                                            expires: DateTime.Now.AddMinutes(30),
                                            signingCredentials: creds);

            var tokenEncd = new JwtSecurityTokenHandler().WriteToken(token);

            result.JwtToken = new JwtToken
            {
                Token = tokenEncd,
                UserName = claimsIdentity.Name
            };

            return result;
        }

        public ClaimsPrincipal GetClaims(String token)
        {
            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;
            var validateParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = JwtConst.ISSUER,
                ValidAudience = JwtConst.AUDIENCE,
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtConst.SECURITY_KEY))
            };

            ClaimsPrincipal claimsPrincipal = securityTokenHandler.ValidateToken(token, validateParameters, out validatedToken);

            return claimsPrincipal;
        }
    }
}
