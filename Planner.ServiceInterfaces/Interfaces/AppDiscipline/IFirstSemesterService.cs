using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppDiscipline
{
    public interface IFirstSemesterService
    {
        Task<int> InsertFirstSemester(FirstSemesterDto firstSemesterDto);
    }
}
