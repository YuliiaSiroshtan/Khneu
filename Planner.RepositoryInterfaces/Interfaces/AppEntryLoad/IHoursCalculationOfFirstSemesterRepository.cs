using Planner.Entities.Domain.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppEntryLoad
{
    public interface IHoursCalculationOfFirstSemesterRepository
    {
        Task<int> InsertHoursCalculationOfFirstSemester(
            HoursCalculationOfFirstSemester hoursCalculationOfFirstSemester);
    }
}