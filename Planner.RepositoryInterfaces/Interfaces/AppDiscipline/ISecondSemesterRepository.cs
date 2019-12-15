using Planner.Entities.Domain.AppEntryLoad.FullTime;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppDiscipline
{
    public interface ISecondSemesterRepository
    {
        Task<int> InsertSecondSemester(SecondSemester secondSemester);
    }
}