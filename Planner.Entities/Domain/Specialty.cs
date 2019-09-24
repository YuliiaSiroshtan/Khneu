using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class Specialty
    {
        public String SpecialtyId { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }

        public virtual ICollection<DayEntryLoad> DayEntryLoads { get; set; }
    }
}
