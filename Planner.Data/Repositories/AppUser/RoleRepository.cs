using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppUser;
using Planner.RepositoryInterfaces.Interfaces.AppUser;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppUser
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

        public async Task<Role> GetRoleById(int id) => await this.GetEntityById(id);

        public async Task<Role> GetRoleByName(string name) => await this.GetEntityByName(name);
    }
}