using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class ScientificPublishing
    {
        public String ScientificPublishingId { get; set; }
        public String ApplicationUserId { get; set; }
        public Int32 Year { get; set; }
        public Int32 Monographs { get; set; }
        public Int32 MonographsNationalPublications { get; set; }
        public Int32 MonographsForeignJournals { get; set; }
        public Int32 AllPublications { get; set; }
        public Int32 ScientificPublicationsInScopus { get; set; }
        public Int32 ArticlesThesesInNmbd { get; set; }
        public Int32 ScientificPublicationsInForeignJournals { get; set; }
        public Int32 ArticlesInProfessionalPublications { get; set; }
        public Int32 ScientificArticlesInForeignLanguages { get; set; }
        public Int32 Abstracts { get; set; }

        public ApplicationUser User { get; set; }
    }
}
