namespace Planner.PresentationLayer.ViewModels
{
    public class PartTimeDisciplineViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string KRKPDR { get; set; }

        public string Language { get; set; }

        public string NumberOfDeaneryMembers { get; set; }

        public ConstituentSessionViewModel ConstituentSession { get; set; }

        public ExaminationSessionViewModel ExaminationSession { get; set; }

        public DepartmentViewModel Department { get; set; }
    }
}
