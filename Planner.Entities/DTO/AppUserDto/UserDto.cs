using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.Entities.DTO.UniversityUnits;
using System.Collections.Generic;

namespace Planner.Entities.DTO.AppUserDto
{
    public class UserDto
    {
        public int Id { get; set; }

        public int LdapId { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public RoleDto Role { get; set; }

        public ICollection<RateDto> Rates { get; set; }

        public ICollection<IndividualPlanDto> IndividualPlans { get; set; }

        public ICollection<DepartmentDto> Departments { get; set; }

        public ICollection<SelectedDisciplineDto> SelectedDisciplines { get; set; }

        #region TempData

        public string Login { get; set; }

        public string Password { get; set; }

        #endregion
    }
}