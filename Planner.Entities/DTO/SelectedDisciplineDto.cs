using System.Collections.Generic;
using Planner.Entities.DTO.AppUserDto;

namespace Planner.Entities.DTO
{
    public class SelectedDisciplineDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string Language { get; set; }

        public string WeeksInFirstSemester { get; set; }

        public string WeeksInSecondSemester { get; set; }

        public DepartmentDto Department { get; set; }

        public ICollection<UserDto> Users { get; set; }
    }
}
