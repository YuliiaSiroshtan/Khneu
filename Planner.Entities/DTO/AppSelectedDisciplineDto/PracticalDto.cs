using Planner.Entities.DTO.AppUserDto;

namespace Planner.Entities.DTO.AppSelectedDisciplineDto
{
    public class PracticalDto
    {
        public int Id { get; set; }

        public string AmountOfHours { get; set; }

        public SelectedDisciplineDto SelectedDiscipline { get; set; }

        public UserDto User { get; set; }
    }
}
