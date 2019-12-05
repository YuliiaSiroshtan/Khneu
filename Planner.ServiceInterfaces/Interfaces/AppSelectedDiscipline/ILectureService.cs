using Planner.Entities.DTO.AppSelectedDisciplineDto;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline
{
    public interface ILectureService
    {
        Task<int> InsertLecture(LectureDto lectureDto);
    }
}