using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class IndivPlanFieldsValue
    {
        public String IndivPlanFieldsValueId { get; set; }
        public String SchemaName { get; set; }
        /// <summary>
        /// Фактический обьем
        /// </summary>
        public String Result { get; set; }
        /// <summary>
        /// Плановый обьем обьем
        /// </summary>
        public String PlannedValue { get; set; }
        public String ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
