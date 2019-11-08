using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppUser;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetRoles();

        Task DeleteRole(int id);

        Task<Role> GetRoleById(int id);

        Task<Role> GetRoleByName(string name);

        Task UpdateRole(Role role);

        Task<int> InsertRole(Role role);
    }
}
