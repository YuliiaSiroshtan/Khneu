using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.Domain.UniversityUnits;
using System.Collections.Generic;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppUser
{
    public class User
    {
        public int Id { get; set; }

        public string LdapId { get; set; }

        #region TempData

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        #endregion

        public string ImageSource { get; set; }

        public int? RoleId { get; set; }


        [Description("Ignore")]
        public Role Role { get; set; }


        [Description("Ignore")]
        public ICollection<Rate> Rates { get; set; }


        [Description("Ignore")]
        public ICollection<IndividualPlan> IndividualPlans { get; set; }


        [Description("Ignore")]
        public ICollection<Department> Departments { get; set; }


        [Description("Ignore")]
        public ICollection<SelectedDiscipline> SelectedDisciplines { get; set; }

        public User()
        {
            Departments ??= new HashSet<Department>();

            IndividualPlans ??= new HashSet<IndividualPlan>();

            Rates ??= new HashSet<Rate>();

            SelectedDisciplines ??= new HashSet<SelectedDiscipline>();
        }
    }
}
