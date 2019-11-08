using System.Collections.Generic;
using Planner.Entities.Domain.AppUser;

namespace Planner.Entities.DTO.AppUserDto
{
    public class UserDto
    {
        public int Id { get; set; }

        #region TempData

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        #endregion

        public string ImageSource { get; set; }

        public RoleDto Role { get; set; }

        public ICollection<RateDto> Rates { get; set; }

        public ICollection<IndividualPlanDto> IndividualPlans { get; set; }

        public ICollection<DepartmentDto> Departments { get; set; }

        public ICollection<SelectedDisciplineDto> SelectedDisciplines { get; set; }
    }
}
