using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppEntryLoad.FullTime;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
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
