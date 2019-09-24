using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class NDR
    {
        public String NDRId { get; set; }

        public String FullName { get; set; }

        public String Type { get; set; }

        public String Level { get; set; }

        public String Name { get; set; }

        public String Step { get; set; }

        public String Place { get; set; }

        public String StudentName { get; set; }
        public String Awards { get; set; }
        public String ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
