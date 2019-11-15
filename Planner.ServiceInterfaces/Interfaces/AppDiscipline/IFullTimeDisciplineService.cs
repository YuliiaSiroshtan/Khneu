using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppDiscipline
{
    public interface IFullTimeDisciplineService
    {
        Task<IEnumerable<FullTimeDisciplineDto>> GetFullTineDisciplines();

        Task<IEnumerable<FullTimeDisciplineDto>> GetFullTimeDisciplinesByDepartmentId(int id);

        Task DeleteFullTimeDiscipline(int id);

        Task<FullTimeDisciplineDto> GetFullTimeDisciplineById(int id);

        Task<FullTimeDisciplineDto> GetFullTimeDisciplineByName(string name);

        Task UpdateFullTimeDiscipline(FullTimeDisciplineDto fullTimeDisciplineDto);

        Task<int> InsertFullTimeDiscipline(FullTimeDisciplineDto fullTimeDisciplineDto);
    }
}
