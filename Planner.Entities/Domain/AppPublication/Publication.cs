using Planner.Entities.Domain.Base;
using Planner.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Planner.Entities.Domain.AppPublication
{
    public class Publication : BaseEntity
    {
        //public string PublicationId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        //public double? Pages { get; set; }
        public string Pages { get; set; }
        public string Output { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public bool IsPublished { get; set; }
        public bool IsOverseas { get; set; }
        public string OwnerId { get; set; }
        public int CitationNumberNMBD { get; set; }
        public double ImpactFactorNMBD { get; set; }

        [Description("Ignore")] public ResearchDoneTypeEnum ResearchDoneTypeId { get; set; }
        [Description("Ignore")] public StoringTypeEnum StoringTypeId { get; set; }
        [Description("Ignore")] public PublicationTypeEnum PublicationTypeId { get; set; }
        public string NMBDId { get; set; }

        //public virtual ICollection<PublicationNMBD> PublicationNMBDs { get; set; }
        //public virtual ICollection<NMBD> PublicationNMBDs { get; set; }
        [Description("Ignore")] public virtual NMBD NMBD { get; set; }
        [Description("Ignore")] public virtual ICollection<PublicationUser> PublicationUsers { get; set; }
    }
}
