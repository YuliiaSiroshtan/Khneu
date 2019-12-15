using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.Domain.Base;
using Planner.Entities.Domain.UniversityUnits;
using System.Collections.Generic;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppUser
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Departments ??= new HashSet<Department>();

            this.IndividualPlans ??= new HashSet<IndividualPlan>();

            this.Rates ??= new HashSet<Rate>();

            this.SelectedDisciplines ??= new HashSet<SelectedDiscipline>();
        }

        public string LdapId { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public int? RoleId { get; set; }


        [Description("Ignore")] public Role Role { get; set; }


        [Description("Ignore")] public ICollection<Rate> Rates { get; set; }


        [Description("Ignore")] public ICollection<IndividualPlan> IndividualPlans { get; set; }
        
        public int? DepartmentId { get; set; }

        [Description("Ignore")] public Department Department { get; set; }


        [Description("Ignore")] public ICollection<Department> Departments { get; set; }


        [Description("Ignore")] public ICollection<SelectedDiscipline> SelectedDisciplines { get; set; }

        #region TempData

        public string Login { get; set; }

        public string Password { get; set; }

        #endregion
    }
}