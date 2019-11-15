using Planner.Entities.DTO.UniversityUnits;

namespace Planner.Entities.DTO.AppEntryLoadDto.FullTime
{
    public class FullTimeDisciplineDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string Language { get; set; }

        public string WeeksInFirstSemester { get; set; }

        public string WeeksInSecondSemester { get; set; }

        public FirstSemesterDto FirstSemester { get; set; }

        public SecondSemesterDto SecondSemester { get; set; }

        public DepartmentDto Department { get; set; }
    }
}
