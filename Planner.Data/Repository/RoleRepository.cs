using Planner.Data.BaseRepository;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Data.Context;
using System.Linq;

namespace Planner.Data.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext _context) : base(_context)
        {
        }

        public Role GetRoleByName(String roleName)
        {
            return Query.FirstOrDefault(s => s.Name == roleName);
        }
    }
}
