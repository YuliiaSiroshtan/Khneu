using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppDiscipline
{
    public interface IPartTimeDisciplineService
    {
        Task<IEnumerable<PartTimeDisciplineDto>> GetPartTimeDisciplinesByDepartmentId(int id);

        Task<int> InsertPartTimeDiscipline(PartTimeDisciplineDto partTimeDisciplineDto);
    }
}