using Planner.Entities.Domain.AppUser;
using Planner.Entities.Domain.Base;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppSelectedDiscipline
{
    public class Laboratory : BaseEntity
    {
        public string AmountOfHours { get; set; }

        public int? SelectedDisciplineId { get; set; }

        [Description("Ignore")] public SelectedDiscipline SelectedDiscipline { get; set; }

        public int? UserId { get; set; }

        [Description("Ignore")] public User User { get; set; }
    }
}