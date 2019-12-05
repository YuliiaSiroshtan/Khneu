using Planner.Entities.Domain.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppSelectedDiscipline
{
    public interface ILectureRepository
    {
        Task<int> InsertLecture(Lecture lecture);
    }
}