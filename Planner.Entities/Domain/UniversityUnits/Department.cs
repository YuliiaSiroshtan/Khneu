using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppUser;
using System.Collections.Generic;
using System.ComponentModel;

namespace Planner.Entities.Domain.UniversityUnits
{
    public class Department
    {
        public Department()
        {
            this.Users ??= new HashSet<User>();

            this.FullTimeDisciplines ??= new HashSet<FullTimeDiscipline>();

            this.FullTimeDisciplinesInGraduateSchool ??= new HashSet<FullTimeDiscipline>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CodeDepartment { get; set; }

        public string Classification { get; set; }

        public int? FacultyId { get; set; }

        [Description("Ignore")] public Faculty Faculty { get; set; }

        [Description("Ignore")] public ICollection<User> Users { get; }

        [Description("Ignore")] public ICollection<FullTimeDiscipline> FullTimeDisciplines { get; }

        [Description("Ignore")] public ICollection<FullTimeDiscipline> FullTimeDisciplinesInGraduateSchool { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is Department item)) return false;

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode() => this.Id.GetHashCode();
    }
}