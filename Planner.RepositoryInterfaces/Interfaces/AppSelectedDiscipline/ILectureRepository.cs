using Planner.Entities.Domain.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppSelectedDiscipline
{
    public interface ILectureRepository
    {
        Task<int> InsertLecture(Lecture lecture);
    }
}