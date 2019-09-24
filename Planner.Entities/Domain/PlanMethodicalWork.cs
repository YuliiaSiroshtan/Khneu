using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class PlanMethodicalWork
    {
        public String PlanMethodicalWorkId { get; set; }

        public Int32 OrderNumber { get; set; }
        public String Content { get; set; }
        public String Result { get; set; }
        public Int32 DurationTime { get; set; }
        public Int32 PlannedVolume { get; set; }
        public Int32 ActualVolume { get; set; }
        public String ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
