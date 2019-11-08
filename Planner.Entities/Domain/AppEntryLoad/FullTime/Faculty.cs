using System.Collections.Generic;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppEntryLoad.FullTime
{
    public class Faculty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CodeFaculty { get; set; }
        
        [Description("Ignore")]
        public ICollection<Department> Departments { get; set; }

        public Faculty()
        {
            Departments ??= new HashSet<Department>();
        }
    }
}
