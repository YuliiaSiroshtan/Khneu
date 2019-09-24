using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class PlanChange
    {
        public String PlanChangeId { get; set; }
        public Int32 Semester { get; set; }
        public String TypesfJobs { get; set; }
        public String Changes { get; set; }
        public Int32 PlannedVolume { get; set; }
        public Int32 ActualVolume { get; set; }
        public String Base { get; set; }
        public String Signature { get; set; }
        public String ApplicationUserId { get; set; }
 
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
