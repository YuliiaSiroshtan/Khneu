using Planner.Entities.Domain.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad
{
    public interface IHoursCalculationOfSecondSemesterRepository
    {
        Task<int> InsertHoursCalculationOfSecondSemester(HoursCalculationOfSecondSemester hoursCalculationOfSecondSemester);
    }
}
