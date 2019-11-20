using Planner.Entities.Domain.AppEntryLoad.PartTime;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline
{
    public interface IExaminationSessionRepository
    {
        Task<int> InsertExaminationSession(ExaminationSession examinationSession);
    }
}
