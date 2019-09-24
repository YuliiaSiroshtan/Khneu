using Planner.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IPublicationRepositpry
    {
        IEnumerable<Publication> GetAllPublications();
        void AddUpdate(Publication publication);
        Publication GetById(String publicationId);
    }
}
