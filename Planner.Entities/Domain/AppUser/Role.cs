using System.Collections.Generic;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppUser
{
    public class Role
    {
        public Role() => this.Users ??= new HashSet<User>();

        public int Id { get; set; }

        public string Name { get; set; }

        [Description("Ignore")] public ICollection<User> Users { get; }
    }
}