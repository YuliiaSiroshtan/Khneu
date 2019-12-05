using Planner.Entities.DTO.UniversityUnits;
using System.ComponentModel;

namespace Planner.Entities.DTO.AppEntryLoadDto.FullTime
{
    public class FullTimeEntryLoadDto
    {
        [Description("Ignore")] public int Id { get; set; }

        [Description("Ignore")] public FacultyDto Faculty { get; set; }

        public string Specialty { get; set; }
        public string Specialization { get; set; }
        public string Course { get; set; }
        public string EducationalDegree { get; set; }
        public string AmountOfStudents { get; set; }
        public string AmountOfForeignersStudents { get; set; }
        public string GroupCode { get; set; }
        public string NumberOfGroups { get; set; }
        public string RealNumberOfGroups { get; set; }
        public string NumberOfSubGroups { get; set; }
        public string AmountOfStudentsStreams { get; set; }
        public string ConnectingOfStudentStreams { get; set; }
        public string Notes { get; set; }

        [Description("Ignore")] public FullTimeDisciplineDto FullTimeDiscipline { get; set; }

        [Description("Ignore")] public HoursCalculationOfFirstSemesterDto HoursCalculationOfFirstSemester { get; set; }

        [Description("Ignore")]
        public HoursCalculationOfSecondSemesterDto HoursCalculationOfSecondSemester { get; set; }

        public string KRKPDR { get; set; }
        public string Practical { get; set; }
        public string AmountOfPeopleDec { get; set; }
        public string All { get; set; }
        public string Active { get; set; }
    }
}