using System.Collections.Generic;
using System.ComponentModel;
using Planner.Entities.Domain.AppUser;

namespace Planner.Entities.DTO.AppUserDto
{
    public class RoleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserDto> Users { get; }
    }
}
