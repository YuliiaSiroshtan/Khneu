using Planner.ServiceInterfaces.DTO.Distribution;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IDistributionService
    {
        IEnumerable<DayEntryDTO> GetDayEntry(int semester, int year);
    }
}
