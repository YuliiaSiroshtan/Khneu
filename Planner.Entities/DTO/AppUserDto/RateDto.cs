using Planner.Entities.Domain.AppUser;
using System.Collections.Generic;
using Planner.Entities.DTO.UniversityUnits;

namespace Planner.Entities.DTO.AppUserDto
{
    public class RateDto
    {
        public int Id { get; set; }

        public float Value { get; set; }

        public DepartmentDto Department { get; set; }

        public ICollection<User> Users { get; }

    }
}
