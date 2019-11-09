﻿using System;

namespace Planner.Entities.Domain.AppEntryLoad
{
    public class EntryLoadsProperty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateTimeUpload { get; set; }

        public int HoursPerRate { get; set; }

        public bool IsActive { get; set; }
    }
}