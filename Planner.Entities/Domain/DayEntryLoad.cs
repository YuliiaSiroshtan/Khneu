using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class DayEntryLoad
    {
        public String DayEntryLoadId { get; set; }

        public String Language { get; set; }
        public String Note { get; set; }
        public String EducationDegree { get; set; }
        public String ConflatedThreads { get; set; }
        public Double CountOfCredits { get; set; }
        public Double CountOfHours { get; set; }
        public Double HoursPerCredit { get; set; }
        public Double FSemCoefficient { get; set; }
        public Double SSemCoefficient { get; set; }
        public Double F_TotalHour { get; set; }
        public Double F_Total { get; set; }
        public Double F_Lectures { get; set; }
        public Double F_Labs { get; set; }
        public Double F_Practical { get; set; }
        public Double F_IndividualWork { get; set; }
        public String F_CourseProjects { get; set; }
        public String F_Exams { get; set; }
        public String F_Evaluation { get; set; }
        public Double S_TotalHour { get; set; }
        public Double S_Total { get; set; }
        public Double S_Lectures { get; set; }
        public Double S_Labs { get; set; }
        public Double S_Practical { get; set; }
        public Double S_IndividualWork { get; set; }
        public String S_CourseProjects { get; set; }
        public String S_Exams { get; set; }
        public String S_Evaluation { get; set; }
        public String DepartmentCipher { get; set; }
        public Double FS_CountOfWeeks { get; set; }
        public Double SS_CountOfWeeks { get; set; }
        public Double QuantityOfStudents { get; set; }
        public Double QuantityOfForeigners { get; set; }
        public String CipherOfGroups { get; set; }
        public Double QuantityOfGroupsCritOne { get; set; }
        public Double RealQuantityOfGroups { get; set; }
        public Double QuantityOfGroupsCritTwo { get; set; }
        public Double QuantityOfThreads { get; set; }
        public Double CipherOfThreads { get; set; }
        public Double KR_KP_DR { get; set; }
        public Double Practice { get; set; }
        public Double QuantityOfDek { get; set; }
        public String FacultyName { get; set; } //+

        public String LoadingListId { get; set; }
        public String DepartmentId { get; set; }
        public String SpecialtyId { get; set; }
        public String SpecializeId { get; set; }
        public String CourseId { get; set; }
        public String SubjectId { get; set; }

        public virtual LoadingList LoadingList { get; set; }
        public virtual Department Department { get; set; }
        public virtual Specialty Specialty { get; set; }
        public virtual Specialize Specialize { get; set; }
        public virtual Course Course { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<DaySemester> DaySemesters { get; set; }
    }
}
