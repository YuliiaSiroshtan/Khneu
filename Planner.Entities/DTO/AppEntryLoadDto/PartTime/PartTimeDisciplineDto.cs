using Planner.Entities.DTO.UniversityUnits;
using System.ComponentModel;

namespace Planner.Entities.DTO.AppEntryLoadDto.PartTime
{
    public class PartTimeDisciplineDto
    {
        [Description("Ignore")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ECTS { get; set; }
        public string AmountOfHours { get; set; }
        public string KRKPDR { get; set; }
        public string Language { get; set; }
        public string NumberOfDeaneryMembers { get; set; }

        [Description("Ignore")]
        public ConstituentSessionDto ConstituentSession { get; set; }

        [Description("Ignore")]
        public ExaminationSessionDto ExaminationSession { get; set; }

        [Description("Ignore")]
        public DepartmentDto Department { get; set; }

    }
}
