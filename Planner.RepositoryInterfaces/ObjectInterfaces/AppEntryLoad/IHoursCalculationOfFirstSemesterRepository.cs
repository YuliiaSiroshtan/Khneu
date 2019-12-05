using Planner.Entities.Domain.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad
{
    public interface IHoursCalculationOfFirstSemesterRepository
    {
        Task<int> InsertHoursCalculationOfFirstSemester(
            HoursCalculationOfFirstSemester hoursCalculationOfFirstSemester);
    }
}