using Planner.Entities.DTO.AppPublicationDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppPublication
{
    public interface IPublicationService
    {
        Task<IEnumerable<NmbdDTO>> GetAllNmbds();

        //Boolean UpdatePublication(PublicationAddEditDTO publicationDTO, String userName);
        //void UodatePublication(Publication);

        Task<IEnumerable<PublicationDTO>> GetPublications();
        Task<PublicationDTO> GetPublicationById(string id);
    }
}
