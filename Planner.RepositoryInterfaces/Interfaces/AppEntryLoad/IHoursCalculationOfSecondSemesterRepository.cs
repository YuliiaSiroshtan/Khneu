using Planner.Entities.Domain.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppEntryLoad
{
    public interface IHoursCalculationOfSecondSemesterRepository
    {
        Task<int> InsertHoursCalculationOfSecondSemester(
            HoursCalculationOfSecondSemester hoursCalculationOfSecondSemester);
    }
}