using Planner.Entities.Domain.AppEntryLoad.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppDiscipline
{
    public interface IFullTimeDisciplineRepository
    {
        Task<IEnumerable<FullTimeDiscipline>> GetFullTimeDisciplinesByDepartmentId(int id);

        Task<int> InsertFullTimeDiscipline(FullTimeDiscipline fullTimeDiscipline);
    }
}