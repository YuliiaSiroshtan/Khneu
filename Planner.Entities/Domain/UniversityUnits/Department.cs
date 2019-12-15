using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Planner.Entities.Domain.UniversityUnits
{
    public class Department : BaseEntity, IEquatable<Department>
    {
        public Department()
        {
            this.Users ??= new HashSet<User>();

            this.FullTimeDisciplines ??= new HashSet<FullTimeDiscipline>();

            this.FullTimeDisciplinesInGraduateSchool ??= new HashSet<FullTimeDiscipline>();
        }
        
        public string Name { get; set; }

        public string CodeDepartment { get; set; }

        public string Classification { get; set; }

        public int? FacultyId { get; set; }

        [Description("Ignore")] public Faculty Faculty { get; set; }

        [Description("Ignore")] public ICollection<User> Users { get; }

        [Description("Ignore")] public ICollection<FullTimeDiscipline> FullTimeDisciplines { get; }

        [Description("Ignore")] public ICollection<FullTimeDiscipline> FullTimeDisciplinesInGraduateSchool { get; }


        public bool Equals(Department other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return this.Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == this.GetType() && this.Equals((Department) obj);
        }

        public override int GetHashCode() => this.Id.GetHashCode();
    }
}