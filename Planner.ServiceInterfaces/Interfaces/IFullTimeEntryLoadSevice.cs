using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IFullTimeEntryLoadService
    {
        Task<IEnumerable<FullTimeEntryLoadDto>> GetFullTimeEntryLoads();

        Task DeleteFullTimeEntryLoad(int id);

        Task<FullTimeEntryLoadDto> GetFullTimeEntryLoadById(int id);

        Task UpdateFullTimeEntryLoad(FullTimeEntryLoadDto fullTimeEntryLoadDto);

        Task InsertFullTimeEntryLoad(FullTimeEntryLoadDto fullTimeEntryLoadDto);
    }
}
