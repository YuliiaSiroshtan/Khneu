using Planner.Entities.Domain.Base;
using Planner.Entities.Domain.UniversityUnits;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppEntryLoad.PartTime
{
    public class PartTimeDiscipline : BaseEntity
    {
        public string Name { get; set; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string KRKPDR { get; set; }

        public string Language { get; set; }

        public string NumberOfDeaneryMembers { get; set; }

        public int? ConstituentSessionId { get; set; }

        [Description("Ignore")] public ConstituentSession ConstituentSession { get; set; }

        public int? ExaminationSessionId { get; set; }

        [Description("Ignore")] public ExaminationSession ExaminationSession { get; set; }

        public int? DepartmentId { get; set; }

        [Description("Ignore")] public Department Department { get; set; }
    }
}