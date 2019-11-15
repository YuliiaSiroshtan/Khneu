using Planner.Entities.Domain.AppEntryLoad.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline
{
    public interface IFullTimeDisciplineRepository
    {
        Task<IEnumerable<FullTimeDiscipline>> GetFullTimeDisciplines();

        Task<IEnumerable<FullTimeDiscipline>> GetFullTimeDisciplinesByDepartmentId(int id);

        Task DeleteFullTimeDiscipline(int id);

        Task<FullTimeDiscipline> GetFullTimeDisciplineById(int id);

        Task<FullTimeDiscipline> GetFullTimeDisciplineByName(string name);

        Task UpdateFullTimeDiscipline(FullTimeDiscipline fullTimeDiscipline);

        Task<int> InsertFullTimeDiscipline(FullTimeDiscipline fullTimeDiscipline);
    }
}
