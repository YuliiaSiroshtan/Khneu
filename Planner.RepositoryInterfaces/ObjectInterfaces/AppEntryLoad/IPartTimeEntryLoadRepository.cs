using Planner.Entities.Domain.AppEntryLoad.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad
{
    public interface IPartTimeEntryLoadRepository
    {
        Task<IEnumerable<PartTimeEntryLoad>> GetPartTimeEntryLoads();

        Task<IEnumerable<PartTimeEntryLoad>> GetPartTimeEntryLoadsByUserId(int id);

        Task<PartTimeEntryLoad> GetPartTimeEntryLoadById(int id);

        Task<int> InsertPartTimeEntryLoad(PartTimeEntryLoad partTimeEntryLoad);
    }
}