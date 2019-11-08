using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppEntryLoad;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IDisciplineRepository
    {
        Task<IEnumerable<Discipline>> GetDisciplines();

        Task DeleteDiscipline(int id);

        Task<Discipline> GetDisciplineById(int id);

        Task<Discipline> GetDisciplineByName(string name);

        Task UpdateDiscipline(Discipline discipline);

        Task<int> InsertDiscipline(Discipline discipline);
    }
}
