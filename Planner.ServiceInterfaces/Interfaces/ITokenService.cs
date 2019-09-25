using Planner.ServiceInterfaces.DTO.JWT;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface ITokenService
    {
        Task<JwtResult> CreatejwtSecurityToken(string userName, string password);
        ClaimsPrincipal GetClaims(string token);
    }
}
