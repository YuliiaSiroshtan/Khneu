using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class PublicationNMBD
    {
        //public String PublicationNMBDId { get; set; }
        public String PublicationId { get; set; }
        public String NMBDId { get; set; }

        public virtual Publication Publication { get; set; }
        public virtual NMBD NMBD { get; set; }
    }
}
