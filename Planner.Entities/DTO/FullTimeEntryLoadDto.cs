namespace Planner.Entities.DTO
{
    public class FullTimeEntryLoadDto
    {
        public int Id { get; set; }
        public FacultyDto Faculty { get; set; }
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
        public DisciplineDto Discipline { get; set; }
    }
}
