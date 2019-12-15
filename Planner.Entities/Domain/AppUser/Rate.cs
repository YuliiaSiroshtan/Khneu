using Planner.Entities.Domain.Base;
using Planner.Entities.Domain.UniversityUnits;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppUser
{
    public class Rate : BaseEntity, IEquatable<Rate>
    {
        public Rate() => this.Users ??= new HashSet<User>();

        public float Value { get; set; }

        public int? DepartmentId { get; set; }

        [Description("Ignore")] public Department Department { get; set; }

        [Description("Ignore")] public ICollection<User> Users { get; }

        public bool Equals(Rate other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return this.Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == this.GetType() && this.Equals((Rate) obj);
        }

        public override int GetHashCode() => this.Id.GetHashCode();
    }
}