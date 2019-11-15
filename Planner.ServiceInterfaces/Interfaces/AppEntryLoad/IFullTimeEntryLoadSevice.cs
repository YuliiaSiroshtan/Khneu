using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppEntryLoad
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
