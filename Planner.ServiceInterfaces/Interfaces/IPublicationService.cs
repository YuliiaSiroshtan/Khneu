using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.DTO.Publication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IPublicationService
    {
        Task<IEnumerable<NmbdDTO>> GetAllNmbds();
        Task<bool> UpdatePublication(PublicationAddEditDTO publicationDTO, string userName);
        Task<IEnumerable<PublicationDTO>> GetPublications();
        Task<PublicationDTO> GetPublicationById(string id);
    }
}
