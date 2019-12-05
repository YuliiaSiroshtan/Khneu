using Planner.Entities.DTO.UniversityUnits;
using System.ComponentModel;

namespace Planner.Entities.DTO.AppEntryLoadDto.FullTime
{
    public class FullTimeDisciplineDto
    {
        [Description("Ignore")] public int Id { get; set; }

        public string Name { get; set; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string Language { get; set; }

        public string WeeksInFirstSemester { get; set; }

        public string WeeksInSecondSemester { get; set; }

        [Description("Ignore")] public FirstSemesterDto FirstSemester { get; set; }

        [Description("Ignore")] public SecondSemesterDto SecondSemester { get; set; }

        [Description("Ignore")] public DepartmentDto Department { get; set; }
    }
}