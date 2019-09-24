using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class DaySemester
    {
        public String DaySemesterId { get; set; }

        public Byte Semester { get; set; }
        public Double Lecture { get; set; }
        public Double Practice { get; set; }
        public Double Lab { get; set; }
        public Double ConsultInSemester { get; set; }
        public Double ConsultForExam { get; set; }
        public Double VerifyingOfTests { get; set; }
        public Double KR_KP { get; set; }
        public Double ControlEvaluation { get; set; }
        public Double ControlExam { get; set; }
        public Double PracticePreparation { get; set; }
        public Double Dek { get; set; }
        public Double StateExam { get; set; }
        public Double ManagedDiploma { get; set; }
        public Double Other { get; set; }
        public Double Total { get; set; }
        public Double Active { get; set; }
        public Double EnglishBonus { get; set; }

        public String DayEntryLoadId { get; set; }


        public virtual DayEntryLoad DayEntryLoad { get; set; }
    }
}
