using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO.AppUserDto;

namespace Planner.ServiceInterfaces.Interfaces
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
