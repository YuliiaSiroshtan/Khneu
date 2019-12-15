using Planner.Entities.Domain.Base;
using System;

namespace Planner.Entities.Domain.AppUser
{
    public class UserEntryLoadProperty : BaseEntity
    {
        public string Name { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public DateTime DateTimeUpload { get; set; }
    }
}