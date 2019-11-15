using Planner.Entities.Domain.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppUser
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
