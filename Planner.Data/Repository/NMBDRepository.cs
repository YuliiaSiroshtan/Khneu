using Microsoft.EntityFrameworkCore;
using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository
{
    public class NMBDRepository : BaseRepository<NMBD>, INMBDRepository
    {
        public NMBDRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<NMBD>> GetAllNMBD() => await Query.ToListAsync();

        public async Task<NMBD> GetById(string id) => await Query.FirstOrDefaultAsync(s=> s.NMBDId == id);
    }
}
