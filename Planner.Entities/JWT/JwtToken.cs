﻿namespace Planner.Entities.JWT
{
    public class JwtToken
    {
        public string Token { get; set; }

        public string Login { get; set; }
        public string Role { get; set; }
        public string DepartmentId { get; set; } = null;
    }
}