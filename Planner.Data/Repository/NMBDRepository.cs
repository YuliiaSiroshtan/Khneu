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
    public class NMBDRepository : BaseRepository<NMBD>, INMBDRepository
    {
        public NMBDRepository(AppDbContext _context) : base(_context)
        {
        }

        public IEnumerable<NMBD> GetAllNMBD()
        {
            return Query.ToList();
        }
        public NMBD GetById(String id)
        {
            return Query.FirstOrDefault(s=> s.NMBDId == id);
        }
    }
}
