using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppEntryLoad
{
    public interface IPartTimeEntryLoadService
    {
        Task<IEnumerable<PartTimeEntryLoadDto>> GetPartTimeEntryLoads();

        Task<IEnumerable<PartTimeEntryLoadDto>> GetPartTimeEntryLoadsByUserId(int id);

        Task<PartTimeEntryLoadDto> GetPartTimeEntryLoadById(int id);

        Task<int> InsertPartTimeEntryLoad(PartTimeEntryLoadDto partTimeEntryLoadDto);
    }
}