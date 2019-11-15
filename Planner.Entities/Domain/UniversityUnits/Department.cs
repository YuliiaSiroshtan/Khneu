using System.Collections.Generic;
using System.ComponentModel;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppUser;

namespace Planner.Entities.Domain.UniversityUnits
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CodeDepartment { get; set; }

        public string Classification { get; set; }

        public int? FacultyId { get; set; }

        [Description("Ignore")]
        public Faculty Faculty { get; set; }

        [Description("Ignore")]
        public ICollection<User> Users { get; }

        [Description("Ignore")]
        public ICollection<FullTimeDiscipline> FullTimeDisciplines { get; }

        [Description("Ignore")]
        public ICollection<FullTimeDiscipline> FullTimeDisciplinesInGraduateSchool { get; }


        public Department()
        {
            Users ??= new HashSet<User>();

            FullTimeDisciplines ??= new HashSet<FullTimeDiscipline>();

            FullTimeDisciplinesInGraduateSchool ??= new HashSet<FullTimeDiscipline>();

        }

        public override bool Equals(object obj)
        {
            if (!(obj is Department item))
            {
                return false;
            }

            return Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}