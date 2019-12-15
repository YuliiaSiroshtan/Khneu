using Planner.Entities.Domain.Base;

namespace Planner.Entities.Domain.AppEntryLoad
{
    public class HoursCalculationOfSecondSemester : BaseEntity
    {
        public string Lectures { get; set; }
        public string Laboratories { get; set; }
        public string Practicals { get; set; }
        public string ConsultationsDuringTheSemester { get; set; }
        public string ConsultationsBeforeTheExam { get; set; }
        public string CheckingOfControlWorks { get; set; }
        public string KRKP { get; set; }
        public string ConductionOfCredit { get; set; }
        public string ConductionOfExam { get; set; }
        public string PracticalTrainingGuide { get; set; }
        public string ParticipationInDec { get; set; }
        public string ConductionOfTheStateExam { get; set; }
        public string GuidanceDiplomaWorks { get; set; }
        public string Another { get; set; }
        public string All { get; set; }
        public string Active { get; set; }
        public string Bonus { get; set; }
    }
}