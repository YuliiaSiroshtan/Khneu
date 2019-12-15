using Planner.Entities.Domain.Base;
using System.Collections.Generic;
using System.ComponentModel;

namespace Planner.Entities.Domain.UniversityUnits
{
    public class Faculty : BaseEntity
    {
        public Faculty() => this.Departments ??= new HashSet<Department>();

        public string Name { get; set; }

        public string CodeFaculty { get; set; }

        [Description("Ignore")] public ICollection<Department> Departments { get; set; }
    }
}