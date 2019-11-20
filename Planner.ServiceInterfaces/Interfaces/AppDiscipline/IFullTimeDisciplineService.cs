using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppDiscipline
{
    public interface IFullTimeDisciplineService
    {
        Task<IEnumerable<FullTimeDisciplineDto>> GetFullTimeDisciplinesByDepartmentId(int id);

        Task<int> InsertFullTimeDiscipline(FullTimeDisciplineDto fullTimeDisciplineDto);
    }
}
