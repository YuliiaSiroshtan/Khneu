using Planner.Entities.Domain.AppUser;
using Planner.Entities.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Planner.Entities.Domain.AppNdr
{
    public class NDR : BaseEntity
    {
        public string FullName { get; set; }

        public string Type { get; set; }

        public string Level { get; set; }

        public string Name { get; set; }

        public string Step { get; set; }

        public string Place { get; set; }

        public string StudentName { get; set; }
        public string Awards { get; set; }
        public int ApplicationUserId { get; set; }

        [Description("Ignore")]  public virtual User User { get; set; }
    }
}
