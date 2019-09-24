using Planner.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class ApplicationUser
    {
        public String ApplicationUserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String ThirdName { get; set; }
        
        public String ScholarLink { get; set; }
        public String ProfilePicture { get; set; }
        public String BasicOrCompatible { get; set; }
        public String Document { get; set; }
        public Boolean IsActive { get; set; }
        public String OrcidLink { get; set; }
        public String Email { get; set; }
        public String PasswordHash { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public Boolean LockoutEnabled { get; set; }
        public Int32? AccessFailedCount { get; set; }
        public String UserName { get; set; }
        
        public AcademicTitleEnum? AcademicTitleId { get; set; }
        public DegreeEnum? DegreeId { get; set; }
        public PositionEnum? PositionId { get; set; }
        
        public String ScheduleId { get; set; }
        public Int32 RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Schedule Schedule { get; set; }

        public virtual ICollection<ExtramuralTeachLoad> ExtramuralTeachLoad { get; set; }
        public virtual ICollection<DayTeachLoad> DayTeachLoad { get; set; }
        public virtual ICollection<DepartmentUser> DepartmentUsers { get; set; }
        public virtual ICollection<NDR> NDRs { get; set; }
        public virtual ICollection<PublicationUser> PublicationUser { get; set; }
        public virtual ICollection<ScientificPublishing> ScientificPublishings { get; set; }
        public virtual ICollection<PlanChange> PlanChange { get; set; }
        public virtual ICollection<PlanConclusion> PlanConclusion { get; set; }
        public virtual ICollection<PlanManagment> PlanManagment { get; set; }
        public virtual ICollection<PlanMethodicalWork> PlanMethodicalWork { get; set; }
        public virtual ICollection<PlanRemark> PlanRemark { get; set; }
        public virtual ICollection<IndivPlanFieldsValue> IndivPlanFieldsValues { get; set; }
        public virtual ICollection<PlanTrainingJob> PlanTrainingJob { get; set; }
    }
}
