using Planner.Entities.Domain.AppUser;
using Planner.Entities.DTO.UniversityUnits;
using System.Collections.Generic;

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