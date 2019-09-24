using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class PlanConclusion
    {
        public String PlanConclusionId { get; set; }

        public Int32 Semester { get; set; }

        public String Content { get; set; }

        public String Signature { get; set; }

        public String ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
