using Planner.Entities.Domain.Base;
using System;

namespace Planner.Entities.Domain.AppEntryLoad
{
    public class EntryLoadsProperty : BaseEntity
    {
        public string Name { get; set; }

        public DateTime DateTimeUpload { get; set; }

        public int HoursPerRate { get; set; }

        public bool IsActive { get; set; }
    }
}