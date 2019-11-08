using System.Collections.Generic;
using System.ComponentModel;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppUser;

namespace Planner.Entities.Domain.AppEntryLoad
{
    public class SelectedDiscipline
    {
        public int Id { get; set; }

        public string Name { get; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string Language { get; set; }

        public string WeeksInFirstSemester { get; set; }

        public string WeeksInSecondSemester { get; set; }

        public int? DepartmentId { get; set; }

        [Description("Ignore")]
        public Department Department { get; set; }

        [Description("Ignore")]
        public ICollection<User> Users { get; set; }

        public SelectedDiscipline()
        {
            Users ??= new HashSet<User>();
        }
    }
}
