using System;

namespace Planner.Entities.DTO.AppEntryLoadDto
{
    public class EntryLoadsPropertyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateTimeUpload { get; set; }

        public int HoursPerRate { get; set; }

        public bool IsActive { get; set; }
    }
}
