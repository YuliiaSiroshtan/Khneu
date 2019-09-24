using System;

namespace Planner.ServiceInterfaces.DTO.Publication
{
    public class PublicationDTO
    {
        public String PublicationId { get; set; }
        public String Name { get; set; }
        public String FilePath { get; set; }
        public String Pages { get; set; }
        public String Output { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public Boolean IsPublished { get; set; }
        public Boolean IsOverseas { get; set; }
        public String OwnerId { get; set; }
        public Int32 CitationNumberNMBD { get; set; }
        public Int32 ImpactFactorNMBD { get; set; }
        public String CollaboratorsName { get; set; }
    }
}
