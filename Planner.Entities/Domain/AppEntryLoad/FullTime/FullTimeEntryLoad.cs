using Planner.Entities.Domain.UniversityUnits;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppEntryLoad.FullTime
{
    public class FullTimeEntryLoad
    {
        public int Id { get; set; }

        public int? FacultyId { get; set; }

        [Description("Ignore")] public Faculty Faculty { get; set; }

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

        public int? FullTimeDisciplineId { get; set; }

        [Description("Ignore")] public FullTimeDiscipline FullTimeDiscipline { get; set; }

        public int? HoursCalculationOfFirstSemesterId { get; set; }

        [Description("Ignore")] public HoursCalculationOfFirstSemester HoursCalculationOfFirstSemester { get; set; }

        public int? HoursCalculationOfSecondSemesterId { get; set; }

        [Description("Ignore")] public HoursCalculationOfSecondSemester HoursCalculationOfSecondSemester { get; set; }

        public string KRKPDR { get; set; }

        public string Practical { get; set; }

        public string AmountOfPeopleDec { get; set; }

        public string All { get; set; }

        public string Active { get; set; }
    }
}