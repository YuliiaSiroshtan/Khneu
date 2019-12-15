using Planner.Entities.Domain.AppUser;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppUser
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleById(int id);

        Task<Role> GetRoleByName(string name);
    }
}