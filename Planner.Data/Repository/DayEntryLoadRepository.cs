using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Planner.Data.Repository
{
    public class DayEntryLoadRepository : BaseRepository<DayEntryLoad>, IDayEntryLoadRepository
    {
        public DayEntryLoadRepository(AppDbContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<DayEntryLoad>> GetBySemester(int semester, int year)
        {
            return await Query.Include(x=>x.Subject)
                .Include(x=> x.Specialty)
                .Include(x=> x.Specialize)
                .Include(x=> x.Course)
                .Include(x=> x.DaySemesters)
                .Where(s => s.LoadingList.Year == year && s.DaySemesters
                                .Any(x => x.Semester == semester)).ToListAsync();
        }
    }
}
