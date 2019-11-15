using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppDiscipline
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
