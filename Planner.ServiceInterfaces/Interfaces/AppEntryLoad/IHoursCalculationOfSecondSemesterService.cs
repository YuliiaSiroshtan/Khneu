using Planner.Entities.DTO.AppEntryLoadDto;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppEntryLoad
{
    public interface IHoursCalculationOfSecondSemesterService
    {
        Task<int> InsertHoursCalculationOfSecondSemester(
            HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemester);
    }
}