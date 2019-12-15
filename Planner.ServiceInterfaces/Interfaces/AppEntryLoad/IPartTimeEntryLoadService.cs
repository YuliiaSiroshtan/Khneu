using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppEntryLoad
{
    public interface IPartTimeEntryLoadService
    {
        Task<IEnumerable<PartTimeEntryLoad>> GetPartTimeEntryLoads();

        Task<IEnumerable<PartTimeEntryLoadDto>> GetPartTimeEntryLoadsByUserId(int id);

        Task<PartTimeEntryLoad> GetPartTimeEntryLoadById(int id);

        Task<int> InsertPartTimeEntryLoad(PartTimeEntryLoad partTimeEntryLoad);
    }
}