using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppEntryLoad
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
