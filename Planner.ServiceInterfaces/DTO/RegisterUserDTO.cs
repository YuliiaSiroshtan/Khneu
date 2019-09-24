using System;

namespace Planner.ServiceInterfaces.DTO
{
    public class RegisterUserDTO
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String ThirdName { get; set; }
        public String ScholarLink { get; set; }
        public String BasicOrCompatible { get; set; }
        public String Document { get; set; }
        public String OrcidLink { get; set; }
        public String Email { get; set; }
        public String PasswordHash { get; set; }
        public String PhoneNumber { get; set; }
        public Boolean LockoutEnabled { get; set; }
        public String UserName { get; set; }

        public Int32? AcademicTitleId { get; set; }
        public Int32? DegreeId { get; set; }
        public Int32? PositionId { get; set; }

        public String ScheduleId { get; set; }
        public Int32 RoleId { get; set; }
    }

}
