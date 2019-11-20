﻿using System.Collections.Generic;
using System.ComponentModel;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.Domain.UniversityUnits;

namespace Planner.Entities.Domain.AppSelectedDiscipline
{
    public class SelectedDiscipline
    {
        public int Id { get; set; }

        public string Name { get; }

        public string Specialization { get; set; }

        public string Course { get; set; }

        public string ECTS { get; set; }

        public string AmountOfHours { get; set; }

        public string Language { get; set; }

        public string WeeksInFirstSemester { get; set; }

        public string WeeksInSecondSemester { get; set; }

        public string AmountOfLecturesHours { get; set; }

        [Description("Ignore")]
        public ICollection<Lecture> Lectures { get; set; }

        public string AmountOfLaboratoriesHours { get; set; }

        [Description("Ignore")]
        public ICollection<Laboratory> Laboratories { get; set; }

        public string AmountOfPracticalsHours { get; set; }

        [Description("Ignore")]
        public ICollection<Practical> Practicals { get; set; }

        [Description("Ignore")]
        public ICollection<User> Users { get; set; }

        public string FormControl { get; set; }

        public int? DepartmentId { get; set; }

        [Description("Ignore")]
        public Department Department { get; set; }

        public SelectedDiscipline()
        {
            Lectures ??= new HashSet<Lecture>();

            Laboratories ??= new HashSet<Laboratory>();

            Practicals ??= new HashSet<Practical>();

            Users ??= new HashSet<User>();
        }
    }
}
