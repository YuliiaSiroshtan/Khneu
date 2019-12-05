using Planner.Entities.Domain.AppEntryLoad.FullTime;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline
{
    public interface IFirstSemesterRepository
    {
        Task<int> InsertFirstSemester(FirstSemester firstSemester);
    }
}