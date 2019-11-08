using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface ISelectedDisciplineService
    {
        Task<IEnumerable<SelectedDisciplineDto>> GetSelectedDisciplines();

        Task DeleteSelectedDiscipline(int id);

        Task<SelectedDisciplineDto> GetSelectedDisciplineById(int id);

        Task<SelectedDisciplineDto> GetSelectedDisciplineByName(string name);

        Task UpdateSelectedDiscipline(SelectedDisciplineDto selectedDisciplineDto);

        Task<int> InsertSelectedDiscipline(SelectedDisciplineDto selectedDisciplineDto);
    }
}
