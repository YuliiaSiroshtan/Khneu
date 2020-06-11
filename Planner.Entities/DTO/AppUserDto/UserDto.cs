using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.Entities.DTO.UniversityUnits;

namespace Planner.Entities.DTO.AppUserDto
{
    public class UserDto
    {
        public string Id { get; set; }

        public string LdapId { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string ImageSource { get; set; }

        public string RoleName { get; set; }

        public string DepartmentId { get; set; }

        public RateDto[] Rates { get; set; }

        public DepartmentDto[] Departments { get; set; }

        public SelectedDisciplineDto[] SelectedDisciplines { get; set; }
    }
}