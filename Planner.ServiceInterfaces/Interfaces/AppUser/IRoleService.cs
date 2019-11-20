using Planner.Entities.DTO.AppUserDto;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppUser
{
    public interface IRoleService
    {
        Task<RoleDto> GetRoleById(int id);

        Task<RoleDto> GetRoleByName(string name);
    }
}
