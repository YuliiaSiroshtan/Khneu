using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class Department
    {
        public String DepartmentId { get; set; }
        public String Name { get; set; }

        // field for *.xls(x)
        public double Code { get; set; } = 0;

        public String FacultyId { get; set; }


        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<DepartmentUser> DepartmentUsers { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<DayEntryLoad> DayEntryLoads { get; set; }
        public virtual ICollection<ExtramuralEntryLoad> ExtramuralEntryLoads { get; set; }

        public virtual ICollection<LoadingList> LoadingList { get; set; }
    }
}
