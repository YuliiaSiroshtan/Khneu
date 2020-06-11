using Planner.Entities.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain.AppIndividualPlan
{
    public class IndivPlanFields : BaseEntity
    {
        public string IndivPlanFieldsId { get; set; }

        public string DisplayName { get; set; }

        public string SchemaName { get; set; }

        public string Suffix { get; set; }

        public string TabName { get; set; }

        public string IndPlanTypeId { get; set; }

        public virtual IndPlanType IndPlanType { get; set; }
    }
}
