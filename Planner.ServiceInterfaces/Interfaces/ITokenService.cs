using System.Security.Claims;
using System.Threading.Tasks;
using Planner.Entities.JWT;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface ITokenService
    {
        Task<JwtResult> CreateJwtSecurityToken(string userName, string password);

        ClaimsPrincipal GetClaims(string token);
    }
}
