using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class EDataStorage
    {
        public String EDataStorageId { get; set; }

        public Int32 Semester { get; set; }
        public Int32 N { get; set; }
        public String Subject { get; set; }
        public String Specialty { get; set; }
        public String Extramural { get; set; }
        public Double Course { get; set; }
        public Double QuanOfStud { get; set; }
        public Double QuanOfThread { get; set; }
        public Double CommonTime { get; set; }
        public Double Lecture { get; set; }
        public Double Practice { get; set; }
        public Double Lab { get; set; }
        public Double IndWork { get; set; }
        public String Exam { get; set; }
        public String Eval { get; set; }
        public Double Test { get; set; }
        public Double NormKR_KP { get; set; }
        public Double CLecture { get; set; }
        public Double CPractice { get; set; }
        public Double CLab { get; set; }
        public Double CConsultInSem { get; set; }
        public Double CConsultForExam { get; set; }
        public Double CVerifyingTest { get; set; }
        public Double CCourseProject { get; set; }
        public Double CEval { get; set; }
        public Double COralExam { get; set; }
        public Double CManagedDiploma { get; set; }
        public Double CDek { get; set; }
        public Double CVerifyingOfWrWork { get; set; }
        public Double CProtection { get; set; }
        public Double CTotal { get; set; }
        public Double CActive { get; set; }
        public String LoadingListId { get; set; }

        public virtual LoadingList LoadingList { get; set; }
    }
}
