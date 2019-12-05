using System.Collections.Generic;

namespace Planner.Entities.DTO.UniversityUnits
{
    public class FacultyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CodeFaculty { get; set; }

        public ICollection<DepartmentDto> Departments { get; set; }
    }
}