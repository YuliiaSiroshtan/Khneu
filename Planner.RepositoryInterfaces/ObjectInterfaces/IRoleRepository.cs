using Planner.Entities.Domain;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByName(string roleName);
    }
}
