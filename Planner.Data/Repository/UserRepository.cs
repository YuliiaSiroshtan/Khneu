using Microsoft.EntityFrameworkCore;
using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Data.Repository
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ApplicationUser> GetByUserName(string userName) => await Query.AsNoTracking()
                .Include(s => s.Role).FirstOrDefaultAsync(s => s.Email == userName);

        public async Task<ApplicationUser> GetByUserId(string userId) => await Query
                .Include(s => s.Role).FirstOrDefaultAsync(s => s.ApplicationUserId == userId);


        public async Task<ApplicationUser> GetUser(string userName, string password) => await Query
                .Include(s => s.Role)
                .FirstOrDefaultAsync(s => s.Email == userName && s.PasswordHash == password && s.IsActive);

        public async Task<IEnumerable<ApplicationUser>> GetUsers() => await Query.OrderBy(s => s.LastName)
            .ThenBy(x => x.FirstName).ToListAsync();

        public void UpdateUser(ApplicationUser user) => InsertOrUpdateGraph(user);

    }
}
