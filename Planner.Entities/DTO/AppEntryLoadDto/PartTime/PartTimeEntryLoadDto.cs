using System.ComponentModel;

namespace Planner.Entities.DTO.AppEntryLoadDto.PartTime
{
    public class PartTimeEntryLoadDto
    {
        [Description("Ignore")]
        public int Id { get; set; }
        public string Unit { get; set; }
        public string Specialty { get; set; }
        public string Specialization { get; set; }
        public string Course { get; set; }
        public string EducationalDegree { get; set; }
        public string AmountOfStudents { get; set; }
        public string NumberOfGroups { get; set; }
        public string AmountOfStudentsStreams { get; set; }
        public string ConnectingOfStudentStreams { get; set; }
        public string MainSpecial { get; set; }
        public string NumberOfConstituentSession { get; set; }
        public string NumberOfExaminationSession { get; set; }

        [Description("Ignore")]
        public PartTimeDisciplineDto PartTimeDiscipline { get; set; }

        [Description("Ignore")]
        public HoursCalculationOfFirstSemesterDto HoursCalculationOfFirstSemester { get; set; }

        [Description("Ignore")]
        public HoursCalculationOfSecondSemesterDto HoursCalculationOfSecondSemester { get; set; }
        public string All { get; set; }
        public string Active { get; set; }
    }
}
