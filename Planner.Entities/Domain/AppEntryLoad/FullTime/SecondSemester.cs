using Planner.Entities.Domain.Base;

namespace Planner.Entities.Domain.AppEntryLoad.FullTime
{
    public class SecondSemester : BaseEntity
    {
        public string Hours { get; set; }
        public string HoursAll { get; set; }
        public string Lectures { get; set; }
        public string Laboratory { get; set; }
        public string Practical { get; set; }
        public string IndividualWork { get; set; }
        public string CourseWork { get; set; }
        public string Exam { get; set; }
        public string Credit { get; set; }
    }
}