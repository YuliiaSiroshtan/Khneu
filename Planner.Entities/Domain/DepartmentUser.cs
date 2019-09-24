using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class DepartmentUser
    {
        public String DepartmentUserId { get; set; }
        public String RateId { get; set; }
        public String ApplicationUserId { get; set; }
        public String DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Rate Rate { get; set; }
        public virtual ApplicationUser Userrtment { get; set; }

    }
}
