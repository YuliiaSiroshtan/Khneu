using System.ComponentModel;
using Planner.Entities.Domain.UniversityUnits;

namespace Planner.Entities.Domain.AppEntryLoad.FullTime
{
    public class FullTimeEntryLoad
    {
        public int Id { get; set; }

        public int? FacultyId { get; set; }

        [Description("Ignore")]
        public Faculty Faculty { get; set; }

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

        [Description("Ignore")]
        public FullTimeDiscipline FullTimeDiscipline { get; set; }

    }
}
