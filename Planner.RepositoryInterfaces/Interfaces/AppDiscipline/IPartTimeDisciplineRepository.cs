using Planner.Entities.Domain.AppEntryLoad.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppDiscipline
{
    public interface IPartTimeDisciplineRepository
    {
        Task<IEnumerable<PartTimeDiscipline>> GetPartTimeDisciplinesByDepartmentId(int id);

        Task<int> InsertPartTimeDiscipline(PartTimeDiscipline partTimeDiscipline);
    }
}