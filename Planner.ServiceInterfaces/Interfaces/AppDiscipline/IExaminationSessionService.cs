using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppDiscipline
{
    public interface IExaminationSessionService
    {
        Task<int> InsertExaminationSession(ExaminationSessionDto examinationSessionDto);
    }
}
