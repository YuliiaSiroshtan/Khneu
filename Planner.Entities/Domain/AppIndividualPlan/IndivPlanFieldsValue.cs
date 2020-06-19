using Planner.Entities.Domain.AppUser;
using Planner.Entities.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Planner.Entities.Domain.AppIndividualPlan
{
    public class IndivPlanFieldsValue : BaseEntity
    {
        public string SchemaName { get; set; }
        /// <summary>
        /// Фактический обьем
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// Плановый обьем обьем
        /// </summary>
        public string PlannedValue { get; set; }
        public string ApplicationUserId { get; set; }

        [Description("Ignore")] public virtual User ApplicationUser { get; set; }
    }
}
