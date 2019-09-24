using Planner.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IDayEntryLoadRepository
    {
        IEnumerable<DayEntryLoad> GetBySemester(Int32 semester, Int32 year);
    }
}
