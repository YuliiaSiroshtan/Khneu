using Planner.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class AcademicTitle
    {
        public AcademicTitle()
        {
            AcademicTitleId = Guid.NewGuid();
        }
        public Guid AcademicTitleId { get; set; }
        public AcademicTitleEnum Value { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
