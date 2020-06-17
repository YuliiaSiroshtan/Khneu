using Planner.Entities.Domain;
using Planner.Entities.Domain.AppPublication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppPublication
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> GetAllPublications(string userLogin);
        //void AddUpdate(Publication publication);
        Task<Publication> GetById(string publicationId);
    }
}
