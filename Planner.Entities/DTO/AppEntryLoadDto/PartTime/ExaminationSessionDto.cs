﻿using System.ComponentModel;

namespace Planner.Entities.DTO.AppEntryLoadDto.PartTime
{
    public class ExaminationSessionDto
    {
        [Description("Ignore")] public string Id { get; set; }

        public string Hours { get; set; }
        public string HoursAll { get; set; }
        public string Lectures { get; set; }
        public string Laboratory { get; set; }
        public string Practical { get; set; }
        public string IndividualWork { get; set; }
        public string CourseWork { get; set; }
        public string ControlWork { get; set; }
        public string Exam { get; set; }
        public string Credit { get; set; }
    }
}