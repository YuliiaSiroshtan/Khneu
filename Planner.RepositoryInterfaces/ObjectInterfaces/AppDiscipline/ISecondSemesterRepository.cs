using Planner.Entities.Domain.AppEntryLoad.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline
{
    public interface ISecondSemesterRepository
    {
        Task<IEnumerable<SecondSemester>> GetSecondSemesters();

        Task DeleteSecondSemester(int id);

        Task<SecondSemester> GetSecondSemesterById(int id);

        Task UpdateSecondSemester(SecondSemester secondSemester);

        Task<int> InsertSecondSemester(SecondSemester secondSemester);
    }
}
