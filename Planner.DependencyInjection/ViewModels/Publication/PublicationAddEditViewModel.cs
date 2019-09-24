using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.DependencyInjection.ViewModels.Publication
{
    public class PublicationAddEditViewModel
    {
        public String PublicationId { get; set; }
        public String Name { get; set; }
        public String FilePath { get; set; }
        public Int32 Pages { get; set; }
        public String Output { get; set; }
        public Int32 CitationNumberNMBD { get; set; }
        public Int32 ImpactFactorNMBD { get; set; }
        public DateTime PublishedAt { get; set; }
        public String NMBDId { get; set; }
        public Boolean IsOverseas { get; set; }
        public Int32 ResearchDoneType { get; set; }
        public Int32 StoringType { get; set; }
        public Int32 PublicationType { get; set; }

        public List<String> CollaboratorsIds { get; set; }
        public List<String> NewCollaboratorsIds { get;set; }
    }
}
