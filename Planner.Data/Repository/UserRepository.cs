using Microsoft.EntityFrameworkCore;
using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Planner.Data.Repository
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(AppDbContext _context) : base(_context)
        {
        }

        public ApplicationUser GetByUserName(string userName)
        {
            return Query.AsNoTracking()
                        .Include(s => s.Role).FirstOrDefault(s => s.Email == userName);
        }

        public ApplicationUser GetByUserId(string userId) =>
            Query
                .Include(s => s.Role).FirstOrDefault(s => s.ApplicationUserId == userId);


        public ApplicationUser GetUser(string userName, string password)
        {
            return Query
                        .Include(s => s.Role).FirstOrDefault(s => s.Email == userName && s.PasswordHash == password && s.IsActive);
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return Query.OrderBy(s=> s.LastName).ThenBy(x=> x.FirstName).ToList();
        }

        public void UpdateUser(ApplicationUser user)
        {
            InsertOrUpdateGraph(user);
        }
    }
}
