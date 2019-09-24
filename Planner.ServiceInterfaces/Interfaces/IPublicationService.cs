using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.DTO.Publication;
using System;
using System.Collections.Generic;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IPublicationService
    {
        IEnumerable<NmbdDTO> GetAllNmbds();
        //void UodatePublication(Publication);
        Boolean UpdatePublication(PublicationAddEditDTO publicationDTO, String userName);
        IEnumerable<PublicationDTO> GetPublications();
        PublicationDTO GetPublicationById(String id);
    }
}
