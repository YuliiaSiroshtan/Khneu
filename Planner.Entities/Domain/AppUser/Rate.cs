using Planner.Entities.Domain.UniversityUnits;
using System.Collections.Generic;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppUser
{
    public class Rate
    {
        public Rate() => this.Users ??= new HashSet<User>();

        public int Id { get; }

        public float Value { get; set; }

        public int? DepartmentId { get; set; }

        [Description("Ignore")] public Department Department { get; set; }

        [Description("Ignore")] public ICollection<User> Users { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is Rate item)) return false;

            return this.Id.Equals(item.Id);
        }

        public override int GetHashCode() => this.Id.GetHashCode();
    }
}