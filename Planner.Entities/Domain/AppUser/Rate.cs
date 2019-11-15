using Planner.Entities.Domain.AppEntryLoad;
using System.Collections.Generic;
using System.ComponentModel;
using Planner.Entities.Domain.UniversityUnits;

namespace Planner.Entities.Domain.AppUser
{
    public class Rate
    {
        public int Id { get; }

        public float Value { get; set; }

        public int? DepartmentId { get; set; }

        [Description("Ignore")]
        public Department Department { get; set; }

        [Description("Ignore")]
        public ICollection<User> Users { get; }

        public Rate()
        {
            Users ??= new HashSet<User>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Rate item))
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
