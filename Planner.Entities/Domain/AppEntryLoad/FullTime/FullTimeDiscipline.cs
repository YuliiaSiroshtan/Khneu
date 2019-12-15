using Planner.Entities.Domain.Base;
using Planner.Entities.Domain.UniversityUnits;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppEntryLoad.FullTime
{
    public class FullTimeDiscipline : BaseEntity
    {
        public string Name { get; set; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string Language { get; set; }

        public string WeeksInFirstSemester { get; set; }

        public string WeeksInSecondSemester { get; set; }

        public int? FirstSemesterId { get; set; }

        [Description("Ignore")] public FirstSemester FirstSemester { get; set; }

        public int? SecondSemesterId { get; set; }

        [Description("Ignore")] public SecondSemester SecondSemester { get; set; }

        public int? DepartmentId { get; set; }

        [Description("Ignore")] public Department Department { get; set; }
    }
}