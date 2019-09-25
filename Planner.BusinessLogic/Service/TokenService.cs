using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Planner.Common.Constants;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.DTO.JWT;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;

        public TokenService(IUnitOfWork uow, IMapper mapper,
            ISecurityService securityService)
        {
            _uow = uow;
            _mapper = mapper;
            _securityService = securityService;

        }

        public async Task<JwtResult> CreatejwtSecurityToken(string userName, string password)
        {
            var result = new JwtResult();

            var securityPassword = _securityService.GetSha256Hash(password);
            var user = await _uow.UserRepository.GetUser(userName, securityPassword);

            if(user == null)
            {
                result.Error = "Invalid username or password";
                return result;
            }
            if(!user.IsActive)
            {
                result.Error = "Користувач деактивованний!";
                return result;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

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

        public ClaimsPrincipal GetClaims(string token)
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

            var claimsPrincipal = securityTokenHandler.ValidateToken(token, validateParameters, out validatedToken);

            return claimsPrincipal;
        }
    }
}
