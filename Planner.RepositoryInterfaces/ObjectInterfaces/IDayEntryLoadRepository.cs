using Planner.Entities.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IDayEntryLoadRepository
    {
        Task<IEnumerable<DayEntryLoad>> GetBySemester(int semester, int year);
    }
}
