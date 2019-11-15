namespace Planner.Entities.DTO.UniversityUnits
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CodeDepartment { get; set; }

        public string Classification { get; set; }

        public FacultyDto Faculty { get; set; }
    }
}
