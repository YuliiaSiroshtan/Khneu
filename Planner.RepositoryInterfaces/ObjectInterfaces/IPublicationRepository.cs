using Planner.Entities.Domain;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> GetAllPublications();
        void AddUpdate(Publication publication);
        Task<Publication> GetById(string publicationId);
    }
}
