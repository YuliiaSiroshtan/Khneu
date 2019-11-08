using System.Collections.Generic;
using Planner.Entities.Domain.AppUser;

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
