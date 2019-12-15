using Planner.Entities.Domain.AppEntryLoad.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppEntryLoad
{
    public interface IFullTimeEntryLoadRepository
    {
        Task<IEnumerable<FullTimeEntryLoad>> GetFullTimeEntryLoads();

        Task<IEnumerable<FullTimeEntryLoad>> GetFullTimeEntryLoadsByUserId(int id);

        Task<FullTimeEntryLoad> GetFullTimeEntryLoadById(int id);

        Task<int> InsertFullTimeEntryLoad(FullTimeEntryLoad fullTimeEntryLoad);
    }
}