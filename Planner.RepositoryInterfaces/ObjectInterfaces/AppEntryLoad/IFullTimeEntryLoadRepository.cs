using Planner.Entities.Domain.AppEntryLoad.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad
{
    public interface IFullTimeEntryLoadRepository
    {
        Task<IEnumerable<FullTimeEntryLoad>> GetFullTimeEntryLoads();

        Task DeleteFullTimeEntryLoad(int id);

        Task<FullTimeEntryLoad> GetFullTimeEntryLoadById(int id);

        Task UpdateFullTimeEntryLoad(FullTimeEntryLoad fullTimeEntryLoad);

        Task<int> InsertFullTimeEntryLoad(FullTimeEntryLoad fullTimeEntryLoad);
    }
}
