using Planner.Entities.DTO.AppUserDto;
using Planner.Entities.DTO.UniversityUnits;
using System.Collections.Generic;

namespace Planner.Entities.DTO.AppSelectedDisciplineDto
{
    public class SelectedDisciplineDto
    {
        public int Id { get; set; }

        public string Name { get; }

        public string Specialization { get; set; }

        public string Course { get; set; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string Language { get; set; }

        public string WeeksInFirstSemester { get; set; }

        public string WeeksInSecondSemester { get; set; }

        public string AmountOfLecturesHours { get; set; }

        public ICollection<LectureDto> Lectures { get; set; }

        public string AmountOfLaboratoriesHours { get; set; }

        public ICollection<LaboratoryDto> Laboratories { get; set; }

        public string AmountOfPracticalsHours { get; set; }

        public ICollection<PracticalDto> Practicals { get; set; }

        public ICollection<UserDto> Users { get; set; }

        public string FormControl { get; set; }

        public DepartmentDto Department { get; set; }
    }
}