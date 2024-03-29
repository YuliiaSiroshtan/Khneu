﻿using Planner.Entities.Domain.Base;
using System.ComponentModel;

namespace Planner.Entities.Domain.AppEntryLoad.PartTime
{
    public class PartTimeEntryLoad : BaseEntity
    {
        public string Unit { get; set; }

        public string Specialty { get; set; }

        public string Specialization { get; set; }

        public string Course { get; set; }

        public string EducationalDegree { get; set; }

        public string AmountOfStudents { get; set; }

        public string NumberOfGroups { get; set; }

        public string AmountOfStudentsStreams { get; set; }

        public string ConnectingOfStudentStreams { get; set; }

        public string MainSpecial { get; set; }

        public string NumberOfConstituentSession { get; set; }

        public string NumberOfExaminationSession { get; set; }

        public int? PartTimeDisciplineId { get; set; }

        [Description("Ignore")] public PartTimeDiscipline PartTimeDiscipline { get; set; }

        public int? HoursCalculationOfFirstSemesterId { get; set; }

        [Description("Ignore")] public HoursCalculationOfFirstSemester HoursCalculationOfFirstSemester { get; set; }

        public int? HoursCalculationOfSecondSemesterId { get; set; }

        [Description("Ignore")] public HoursCalculationOfSecondSemester HoursCalculationOfSecondSemester { get; set; }

        public string All { get; set; }

        public string Active { get; set; }
    }
}