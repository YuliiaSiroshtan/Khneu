using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppEntryLoad
{
    public interface IFullTimeEntryLoadService
    {
        Task<IEnumerable<FullTimeEntryLoad>> GetFullTimeEntryLoads();

        Task<IEnumerable<FullTimeEntryLoadDto>> GetFullTimeEntryLoadsByUserId(int id);

        Task<FullTimeEntryLoad> GetFullTimeEntryLoadById(int id);

        Task InsertFullTimeEntryLoad(FullTimeEntryLoad fullTimeEntryLoad);
    }
}