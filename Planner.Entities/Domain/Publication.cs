using Planner.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class Publication
    {
        public String PublicationId { get; set; }
        public String Name { get; set; }
        public String FilePath { get; set; }
        public Double? Pages { get; set; }
        public String Output { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public Boolean IsPublished { get; set; }
        public Boolean IsOverseas { get; set; }
        public String OwnerId { get; set; }
        public Int32 CitationNumberNMBD { get; set; }
        public Double ImpactFactorNMBD { get; set; }

        public ResearchDoneTypeEnum ResearchDoneTypeId { get; set; }
        public StoringTypeEnum StoringTypeId { get; set; }
        public PublicationTypeEnum PublicationTypeId { get; set; }
        public String NMBDId { get; set; }

        //public virtual ICollection<PublicationNMBD> PublicationNMBDs { get; set; }
        //public virtual ICollection<NMBD> PublicationNMBDs { get; set; }
        public virtual NMBD NMBD { get; set; }
        public virtual ICollection<PublicationUser> PublicationUsers { get; set; }
    }
}
