using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Entities.Domain
{
    public class PublicationUser
    {
        public String PublicationUserId { get; set; }
        public Double PageQuantity { get; set; }

        public String PublicationId { get; set; }
        public String ApplicationUserId { get; set; }
        public String ExternalCollaboratorId { get; set; }

        public virtual Publication Publication { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ExternalCollaborator Collaborator { get; set; }
    }
}
