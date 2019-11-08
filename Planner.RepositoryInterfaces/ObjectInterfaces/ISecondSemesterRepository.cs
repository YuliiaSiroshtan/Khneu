using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppEntryLoad.FullTime;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
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
