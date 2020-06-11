using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain.AppIndividualPlan
{
    public class IndPlanType
    {
        public string IndPlanTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<IndivPlanFields> IndivPlanFields { get; set; }
    }
}
