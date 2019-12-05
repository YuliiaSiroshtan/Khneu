using System.Collections.Generic;
using System.ComponentModel;

namespace Planner.Entities.Domain.UniversityUnits
{
    public class Faculty
    {
        public Faculty() => this.Departments ??= new HashSet<Department>();

        public int Id { get; set; }

        public string Name { get; set; }

        public string CodeFaculty { get; set; }

        [Description("Ignore")] public ICollection<Department> Departments { get; set; }
    }
}