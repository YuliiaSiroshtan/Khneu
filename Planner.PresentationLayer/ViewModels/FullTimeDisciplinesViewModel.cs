namespace Planner.PresentationLayer.ViewModels
{
    public class FullTimeDisciplinesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string Language { get; set; }

        public string WeeksInFirstSemester { get; set; }

        public string WeeksInSecondSemester { get; set; }

        public FirstSemesterViewModel FirstSemester { get; set; }

        public SecondSemesterViewModel SecondSemester { get; set; }

        public DepartmentViewModel Department { get; set; }
    }
}
