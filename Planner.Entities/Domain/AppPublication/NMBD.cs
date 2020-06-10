using Planner.Entities.Domain.AppPublication;
using Planner.Entities.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain.AppPublication
{
    public class NMBD : BaseEntity
    {
        public string NMBDId { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<PublicationNMBD> PublicationNMBDs { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
       // public virtual ICollection<Publication> PublicationNMBDs { get; set; }

    }
}
