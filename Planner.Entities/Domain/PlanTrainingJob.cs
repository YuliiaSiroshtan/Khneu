using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class PlanTrainingJob
    {
        public String PlanTrainingJobId { get; set; }
        public String EducationForm { get; set; }
        public Int32 OrderNumber { get; set; }
        public String Subject { get; set; }
        public String DSD { get; set; }
        public Int32 Course { get; set; }
        public Int32 CountStudent { get; set; }
        public String GroupCode { get; set; }
        public Int32 PlannedLectures { get; set; }
        public Int32 DoneLectures { get; set; }
        public Int32 PlannedPract { get; set; }
        public Int32 DonePract { get; set; }
        public Int32 PlannedLaboratory { get; set; }
        public Int32 DoneLaboratory { get; set; }
        public Int32 PlannedSeminar { get; set; }
        public Int32 DoneSeminar { get; set; }
        public Int32 PlannedIndividual { get; set; }
        public Int32 DoneIndividual { get; set; }
        public Int32 PlannedConsultation { get; set; }
        public Int32 DoneConsultation { get; set; }
        public Int32 PlannedExamConsultation { get; set; }
        public Int32 DoneExamConsultation { get; set; }
        public Int32 PlannedCheckControl { get; set; }
        public Int32 DoneCheckControl { get; set; }
        public Int32 PlannedCheckLectureControl { get; set; }
        public Int32 DoneCheckLectureControl { get; set; }
        public Int32 PlannedEAT { get; set; }
        public Int32 DoneEAT { get; set; }
        public Int32 PlannedCGS { get; set; }
        public Int32 DoneCGS { get; set; }
        public Int32 PlannedCoursework { get; set; }
        public Int32 DoneCoursework { get; set; }
        public Int32 PlannedOffsetting { get; set; }
        public Int32 DoneOffsetting { get; set; }
        public Int32 PlannedSemestrExam { get; set; }
        public Int32 DoneSemestrExam { get; set; }
        public Int32 PlannedTrainingPract { get; set; }
        public Int32 DoneTrainingPract { get; set; }
        public Int32 PlannedStateExam { get; set; }
        public Int32 DoneStateExam { get; set; }
        public Int32 PlannedDiploma { get; set; }
        public Int32 DoneDiploma { get; set; }
        public Int32 PlannedPostgraduates { get; set; }
        public Int32 DonePostgraduates { get; set; }
        public Int32 PlannedDEK { get; set; }
        public Int32 DoneDEK { get; set; }
        public String ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
