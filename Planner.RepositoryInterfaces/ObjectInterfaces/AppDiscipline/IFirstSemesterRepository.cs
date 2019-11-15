using Planner.Entities.Domain.AppEntryLoad.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline
{
    public interface IFirstSemesterRepository
    {
        Task<IEnumerable<FirstSemester>> GetFirstSemesters();

        Task DeleteFirstSemester(int id);

        Task<FirstSemester> GetFirstSemesterById(int id);

        Task UpdateFirstSemester(FirstSemester firstSemester);

        Task<int> InsertFirstSemester(FirstSemester firstSemester);
    }
}
