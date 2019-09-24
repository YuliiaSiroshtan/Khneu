using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class DDataStorage
    {
        public String DDataStorageId { get; set; }

        public Int32 Semester { get; set; }
        public Int32 N { get; set; }
        public String Subject { get; set; }
        public String Faculty { get; set; }
        public String Specialty { get; set; }
        public String Specialize { get; set; }
        public String Course { get; set; }
        public String EduDegree { get; set; }
        public Double CountOfStud { get; set; }
        public String CipherOfGroup { get; set; }
        public Double QuanOfGroupCritOne { get; set; }
        public Double RealQuanGr { get; set; }
        public String QuanOfGroupCritTwo { get; set; }
        public Double QuanOfThread { get; set; }
        public Double TotalHour { get; set; }
        public Double Total { get; set; }
        public Double Lecture { get; set; }
        public Double Practice { get; set; }
        public Double Lab { get; set; }
        public Double IndWork { get; set; }
        public String CourseProjects { get; set; }
        public String Exam { get; set; }
        public String Eval { get; set; }
        public Double CLecture { get; set; }
        public Double CPractice { get; set; }
        public Double CLab { get; set; }
        public Double CConsultInSem { get; set; }
        public Double CConsultForExam { get; set; }
        public Double CCheckOfTests { get; set; }
        public Double CKR_KP { get; set; }
        public Double CEval { get; set; }
        public Double CExam { get; set; }
        public Double CPracticePreparation { get; set; }
        public Double CDek { get; set; }
        public Double CStateExam { get; set; }
        public Double CManagedDiploma { get; set; }
        public Double COther { get; set; }
        public Double CTotal { get; set; }
        public Double CActive { get; set; }
        public String LoadingListId { get; set; }


        public virtual LoadingList LoadingList { get; set; }
    }
}
