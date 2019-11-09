using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IDisciplineService
    {
        Task<IEnumerable<DisciplineDto>> GetDisciplines();
        
        Task<IEnumerable<DisciplineDto>> GetDisciplinesByDepartmentId(int id);

        Task DeleteDiscipline(int id);

        Task<DisciplineDto> GetDisciplineById(int id);

        Task<DisciplineDto> GetDisciplineByName(string name);

        Task UpdateDiscipline(DisciplineDto disciplineDto);

        Task<int> InsertDiscipline(DisciplineDto disciplineDto);
    }
}
