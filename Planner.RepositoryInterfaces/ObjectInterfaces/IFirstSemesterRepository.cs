using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppEntryLoad.FullTime;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
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
