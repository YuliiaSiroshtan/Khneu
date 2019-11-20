using System.Threading.Tasks;
using Planner.Entities.Domain.AppEntryLoad;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad
{
    public interface IHoursCalculationOfFirstSemesterRepository
    {
        Task<int> InsertHoursCalculationOfFirstSemester(HoursCalculationOfFirstSemester hoursCalculationOfFirstSemester);
    }
}