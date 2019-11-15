using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppUser;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppUser
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<Role>> GetRoles() => await GetEntities();

        public async Task DeleteRole(int id) => await DeleteEntity(id);

        public async Task<Role> GetRoleById(int id) => await GetEntityById(id);

        public async Task<Role> GetRoleByName(string name) => await GetEntityByName(name);

        public async Task UpdateRole(Role role) => await Update(role);

        public async Task<int> InsertRole(Role role) => await Insert(role);
    }
}
