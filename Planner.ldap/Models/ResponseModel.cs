using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.ldap.Models
{
    public class ResponseModel
    {
        public Dictionary<String, String> Data { get; set; } = new Dictionary<String, String>();
    }
}
