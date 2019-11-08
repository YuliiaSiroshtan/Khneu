using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppEntryLoad;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface ISelectedDisciplineRepository
    {
        Task<IEnumerable<SelectedDiscipline>> GetSelectedDisciplines();

        Task DeleteSelectedDiscipline(int id);

        Task<SelectedDiscipline> GetSelectedDisciplineById(int id);

        Task<SelectedDiscipline> GetSelectedDisciplineByName(string name);

        Task UpdateSelectedDiscipline(SelectedDiscipline selectedDiscipline);

        Task<int> InsertSelectedDiscipline(SelectedDiscipline selectedDiscipline);
    }
}
