using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class IndPlanType
    {
        public String IndPlanTypeId { get; set; }

        public String Name { get; set; }

        public virtual ICollection<IndivPlanFields> IndivPlanFields { get; set; }
    }
}
