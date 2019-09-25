using Microsoft.EntityFrameworkCore;
using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System.Threading.Tasks;

namespace Planner.Data.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Role> GetRoleByName(string roleName) => await Query
            .FirstOrDefaultAsync(s => s.Name == roleName);
    }
}
