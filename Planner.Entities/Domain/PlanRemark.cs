using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class PlanRemark
    {
        public String PlanRemarkId { get; set; }


        public DateTime Date { get; set; }

        public String Remark { get; set; }

        public String Signature { get; set; }

        public String ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
