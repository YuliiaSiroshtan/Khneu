using System;

namespace Planner.Entities.Domain.AppUser
{
    public class UserEntryLoadProperty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public DateTime DateTimeUpload { get; set; }
    }
}
