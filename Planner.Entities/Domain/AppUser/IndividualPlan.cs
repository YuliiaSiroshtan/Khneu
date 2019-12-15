using Planner.Entities.Domain.Base;

namespace Planner.Entities.Domain.AppUser
{
    public class IndividualPlan : BaseEntity
    {
        public User User { get; set; }
    }
}