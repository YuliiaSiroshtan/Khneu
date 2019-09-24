using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class Role
    {
        public Int32 RoleId { get; set; }
        public String Name { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}
