using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface ISecondSemesterService
    {
        Task<IEnumerable<SecondSemesterDto>> GetSecondSemesters();

        Task DeleteSecondSemester(int id);

        Task<SecondSemesterDto> GetSecondSemesterById(int id);

        Task UpdateSecondSemester(SecondSemesterDto secondSemesterDto);

        Task<int> InsertSecondSemester(SecondSemesterDto secondSemesterDto);
    }
}
