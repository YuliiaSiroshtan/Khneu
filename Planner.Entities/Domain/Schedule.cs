using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class Schedule
    {
        public String ScheduleId { get; set; }
        public String UserName { get; set; }
        public String ApiId { get; set; }
        public String DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
