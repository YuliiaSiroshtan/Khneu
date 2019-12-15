namespace Planner.Entities.DTO.AppSelectedDisciplineDto
{
    public class SelectedDisciplineDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }

        public string Course { get; set; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string Language { get; set; }

        public string WeeksInFirstSemester { get; set; }

        public string WeeksInSecondSemester { get; set; }

        public string AmountOfLecturesHours { get; set; }

        public LectureDto[] Lectures { get; set; }

        public string AmountOfLaboratoriesHours { get; set; }

        public LaboratoryDto[] Laboratories { get; set; }

        public string AmountOfPracticalsHours { get; set; }

        public PracticalDto[] Practicals { get; set; }

        public string FormControl { get; set; }

        public string DepartmentName { get; set; }
    }
}