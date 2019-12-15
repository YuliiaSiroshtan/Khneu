using Planner.Entities.Domain.Base;
using System.Collections.Generic;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppUser
{
    public class Role : BaseEntity
    {
        public Role() => this.Users ??= new HashSet<User>();

        public string Name { get; set; }

        [Description("Ignore")] public ICollection<User> Users { get; }
    }
}