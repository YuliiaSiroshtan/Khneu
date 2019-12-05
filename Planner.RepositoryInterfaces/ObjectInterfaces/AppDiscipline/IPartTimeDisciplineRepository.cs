using Planner.Entities.Domain.AppEntryLoad.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline
{
    public interface IPartTimeDisciplineRepository
    {
        Task<IEnumerable<PartTimeDiscipline>> GetPartTimeDisciplinesByDepartmentId(int id);

        Task<int> InsertPartTimeDiscipline(PartTimeDiscipline partTimeDiscipline);
    }
}