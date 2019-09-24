using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class ExtramuralEntryLoad
    {
        public String ExtramuralEntryLoadId { get; set; }

        public String DepartmentCipher { get; set; }
        public String Extramural { get; set; }
        public Double Course { get; set; }
        public Double QuantityOfStudents { get; set; }
        public Double QuantityOfGroups { get; set; }
        public Double QuantityOfThreads { get; set; }
        public Double NumOfThread { get; set; }
        public String MajorSpecialty { get; set; }
        public Double CommonTime { get; set; }
        public Double Credits { get; set; }
        public Double F_Lecture { get; set; }
        public Double F_Practical { get; set; }
        public Double F_Lab { get; set; }
        public Double F_IndividualWork { get; set; }
        public String F_Exam { get; set; }
        public String F_Evaluation { get; set; }
        public String F_KR { get; set; }
        public Double F_Test { get; set; }
        public Double F_LimitOnProjects { get; set; } //+
        public Double S_Lecture { get; set; }
        public Double S_Practical { get; set; }
        public Double S_Lab { get; set; }
        public Double S_IndividualWork { get; set; }
        public String S_Exam { get; set; }
        public String S_Evaluation { get; set; }
        public String S_KR { get; set; }
        public Double S_Test { get; set; }
        public Double S_LimitOnProjects { get; set; } //+

        public String LoadingListId { get; set; }
        public String DepartmentId { get; set; }
        public String SubjectId { get; set; }
        public String SpecialtyId { get; set; }
        
        public virtual Specialty Specialty { get; set; }
        public virtual LoadingList LoadingList { get; set; }
        public virtual Department Department { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<ExtramuralSemester> ExtramuralSemesters { get; set; }
    }
}
