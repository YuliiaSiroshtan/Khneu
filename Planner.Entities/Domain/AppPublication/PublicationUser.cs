using Planner.Entities.Domain.AppPublication;
using Planner.Entities.Domain.AppUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class PublicationUser
    {
        public string PublicationUserId { get; set; }
        public double PageQuantity { get; set; }

        public string PublicationId { get; set; }
        public string ApplicationUserId { get; set; }
        public string ExternalCollaboratorId { get; set; }

        public virtual Publication Publication { get; set; }
        public virtual User User { get; set; }
        public virtual ExternalCollaborator Collaborator { get; set; }
    }
}
