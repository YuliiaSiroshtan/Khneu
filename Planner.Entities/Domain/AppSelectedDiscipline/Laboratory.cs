using Planner.Entities.Domain.AppUser;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppSelectedDiscipline
{
    public class Laboratory
    {
        public int Id { get; set; }

        public string AmountOfHours { get; set; }

        public int? SelectedDisciplineId { get; set; }

        [Description("Ignore")] public SelectedDiscipline SelectedDiscipline { get; set; }

        public int? UserId { get; set; }

        [Description("Ignore")] public User User { get; set; }
    }
}