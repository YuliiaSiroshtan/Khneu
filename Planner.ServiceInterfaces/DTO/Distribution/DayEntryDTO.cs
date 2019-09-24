using System;

namespace Planner.ServiceInterfaces.DTO.Distribution
{
    public class DayEntryDTO
    {
        public string DayEntryId { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public string Specialization { get; set; }
        public string Course { get; set; }
        public string EducationDegree { get; set; }
        public double StudentsCount { get; set; }
        public double ForeignersCount { get; set; }
        public string GroupsCipher { get; set; }
        public double QuantityOfGroupsA { get; set; }
        public double RealQuantityOfGroups { get; set; }
        public double QuantityOfGroupsB { get; set; }
        public double QuantityOfThreads { get; set; }
        public string ConflatedThreads { get; set; }
        public string Notes { get; set; }
        public string Subject { get; set; }
        public double QuantityOfCredits { get; set; }
        public double Hours { get; set; }
        public string Language { get; set; }
        public double QuantityOfWeeksFs { get; set; }
        public double QuantityOfWeeksSs { get; set; }
        public double CoeficientFs { get; set; }
        public double CoeficientSs { get; set; }
        public string DepartmentCipher { get; set; }
        public double Projects { get; set; }
        public double Practices { get; set; }
        public double QuantityOfMembers { get; set; }
        public String DayTeachId { get; set; }



        public DayEntrySemesterDTO DeS { get; set; }


        public string DaySemesterId { get; set; }
        public DayDistributionDTO Dd { get; set; }

    }
    public class DayEntrySemesterDTO
    {
        public double TotalHours { get; set; }
        public double Total { get; set; }
        public double Lectures { get; set; }
        public double Labs { get; set; }
        public double Practices { get; set; }
        public double IndependentWorks { get; set; }
        public string Courses { get; set; }
        public string Exam { get; set; }
        public string Evaluation { get; set; }
    }
    public class DayDistributionDTO
    {
        public byte Semester { get; set; }
        public double Lecture { get; set; }
        public double Practice { get; set; }
        public double Lab { get; set; }
        public double ConsultInSemester { get; set; }
        public double ConsultForExam { get; set; }
        public double VerifyingOfTests { get; set; }
        public double KR_KP { get; set; }
        public double ControlEvaluation { get; set; }
        public double ControlExam { get; set; }
        public double PracticePreparation { get; set; }
        public double Dek { get; set; }
        public double StateExam { get; set; }
        public double ManagedDiploma { get; set; }
        public double Other { get; set; }
        public double Total { get; set; }
        public double Active { get; set; }
        public double EnglishBonus { get; set; }
    }
}
