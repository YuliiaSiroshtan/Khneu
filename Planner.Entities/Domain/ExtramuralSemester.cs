using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class ExtramuralSemester
    {
        public String ExtramuralSemesterId { get; set; }

        public Int32 Semester { get; set; }
        public Double Lecture { get; set; }
        public Double Practice { get; set; }
        public Double Lab { get; set; }
        public Double ConsultInSemester { get; set; }
        public Double ConsultForExam { get; set; }
        public Double WrittenWork { get; set; }
        public Double CalcWorks { get; set; }
        public Double CourseProjects { get; set; }
        public Double Evaluation { get; set; }
        public Double OralExam { get; set; }
        public Double WrittenExam { get; set; }
        public Double VerifyingOfTest { get; set; }
        public Double ManagedDiploma { get; set; }
        public Double Dek { get; set; }
        public Double VerifyingOfWrittenWorks { get; set; }
        public Double Protection { get; set; }
        public Double Total { get; set; }
        public Double Active { get; set; }

        public String ExtramuralEntryLoadId { get; set; }


        public virtual ExtramuralEntryLoad ExtramuralEntryLoad { get; set; }
    }
}
