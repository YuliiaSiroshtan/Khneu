using System;

namespace Planner.Entities.DTO.AppPublicationDto
{
    public class PublicationDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Pages { get; set; }
        public string Output { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public bool IsPublished { get; set; }
        public bool IsOverseas { get; set; }
        public string OwnerId { get; set; }
        public int CitationNumberNMBD { get; set; }
        public string CollaboratorsName { get; set; }
        public int ImpactFactorNMBD { get; set; }
        public string NMBDId { get; set; }

    }
}
