using Planner.Entities.Domain.AppEntryLoad.PartTime;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppDiscipline
{
    public interface IExaminationSessionRepository
    {
        Task<int> InsertExaminationSession(ExaminationSession examinationSession);
    }
}