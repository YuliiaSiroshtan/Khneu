using Planner.Entities.DTO.AppUserDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppUser
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetRoles();

        Task DeleteRole(int id);

        Task<RoleDto> GetRoleById(int id);

        Task<RoleDto> GetRoleByName(string name);

        Task UpdateRole(RoleDto roleDto);

        Task<int> InsertRole(RoleDto roleDto);
    }
}
