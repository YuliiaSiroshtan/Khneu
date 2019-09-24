using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class IndivPlanFields
    {
        public String IndivPlanFieldsId { get; set; }

        public String DisplayName { get; set; }

        public String SchemaName { get; set; }

        public String Suffix { get; set; }

        public String TabName { get; set; }

        public String IndPlanTypeId { get; set; }

        public virtual IndPlanType IndPlanType { get; set; }
    }
}
