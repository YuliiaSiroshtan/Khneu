using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppEntryLoad.PartTime;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IPartTimeEntryLoadRepository
    {
        Task<IEnumerable<PartTimeEntryLoad>> GetPartTimeEntryLoads();

        Task DeletePartTimeEntryLoad(int id);

        Task<PartTimeEntryLoad> GetPartTimeEntryLoadById(int id);

        Task UpdatePartTimeEntryLoad(PartTimeEntryLoad partTimeEntryLoad);

        Task<int> InsertPartTimeEntryLoad(PartTimeEntryLoad partTimeEntryLoad);
    }
}
