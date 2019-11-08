namespace Planner.Entities.DTO
{
    public class PartTimeDisciplineDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string KRKPDR { get; set; }

        public string Language { get; set; }

        public string NumberOfDeaneryMembers { get; set; }

        public ConstituentSessionDto ConstituentSession { get; set; }

        public ExaminationSessionDto ExaminationSession { get; set; }

        public DepartmentDto Department { get; set; }
    }
}
