using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppDiscipline
{
    public interface IPartTimeDisciplineService
    {
        Task<IEnumerable<PartTimeDisciplineDto>> GetPartTimeDisciplines();

        Task<IEnumerable<PartTimeDisciplineDto>> GetPartTimeDisciplinesByDepartmentId(int id);

        Task DeletePartTimeDiscipline(int id);

        Task<PartTimeDisciplineDto> GetPartTimeDisciplineById(int id);

        Task<PartTimeDisciplineDto> GetPartTimeDisciplineByName(string name);

        Task UpdatePartTimeDiscipline(PartTimeDisciplineDto partTimeDisciplineDto);

        Task<int> InsertPartTimeDiscipline(PartTimeDisciplineDto partTimeDisciplineDto);
    }
}
