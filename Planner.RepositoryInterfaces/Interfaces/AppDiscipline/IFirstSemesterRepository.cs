using Planner.Entities.Domain.AppEntryLoad.FullTime;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppDiscipline
{
    public interface IFirstSemesterRepository
    {
        Task<int> InsertFirstSemester(FirstSemester firstSemester);
    }
}