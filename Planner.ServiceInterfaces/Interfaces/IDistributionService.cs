using Planner.ServiceInterfaces.DTO.Distribution;
using System;
using System.Collections.Generic;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IDistributionService
    {
        IEnumerable<DayEntryDTO> GetDayEntry(Int32 semester, Int32 year);
    }
}
