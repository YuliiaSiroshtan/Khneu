using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IPartTimeEntryLoadService
    {
        Task<IEnumerable<PartTimeEntryLoadDto>> GetPartTimeEntryLoads();

        Task DeletePartTimeEntryLoad(int id);

        Task<PartTimeEntryLoadDto> GetPartTimeEntryLoadById(int id);

        Task UpdatePartTimeEntryLoad(PartTimeEntryLoadDto partTimeEntryLoadDto);

        Task<int> InsertPartTimeEntryLoad(PartTimeEntryLoadDto partTimeEntryLoadDto);
    }
}
