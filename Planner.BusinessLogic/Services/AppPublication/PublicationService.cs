using AutoMapper;
using Planner.ServiceInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Entities.Domain;
using System.Linq;
using Planner.ServiceInterfaces.Interfaces.AppPublication;
using Planner.Entities.DTO.AppPublicationDto;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppPublication;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.BusinessLogic.Services.Base;

namespace Planner.BusinessLogic.Services.AppPublication
{
    public class PublicationService: BaseService, IPublicationService
    {
        public PublicationService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope, mapper) { }

        public async Task<IEnumerable<NmbdDTO>> GetAllNmbds()
        {
            IEnumerable<NmbdDTO> nmbds = Mapper.Map<IEnumerable<NmbdDTO>>(await RepositoryScope.NMBDRepository.GetAllNMBD());
            return nmbds;
        }

        //public Boolean UpdatePublication(PublicationAddEditDTO publicationDTO, String userName)
        //{
        //    ApplicationUser user = uow.UserRepository.GetByUserName(userName);
        //    //NMBD nmbd = uow.NMBDRepository.GetById(publicationDTO.NMBDId);
        //    Publication existingPublication = null;
        //    Publication publication = _mapper.Map<Publication>(publicationDTO);
        //    if (!String.IsNullOrEmpty(publicationDTO.PublicationId))
        //    {
        //        existingPublication = uow.PublicationRepositpry.GetById(publicationDTO.PublicationId);
        //        publication.PublicationId = publicationDTO.PublicationId;
        //    }

        //    publication.PublishedAt = publicationDTO.PublishedAt.ToUniversalTime();
        //    publication.IsPublished = true;
        //    publication.OwnerId = user.ApplicationUserId;
        //    List<PublicationUser> publicationUsers = new List<PublicationUser>();

        //    foreach (var item in publicationDTO.CollaboratorsIds)
        //    {
        //        publicationUsers.Add(new PublicationUser
        //        {
        //            ApplicationUserId = item,
        //            PageQuantity = publicationDTO.Pages / publicationDTO.CollaboratorsIds.Count

        //        });
        //    }

        //    //PublicationNMBD publicationNMBD = new PublicationNMBD()
        //    //{

        //    //}

        //    publication.PublicationUsers = publicationUsers;



        //    uow.PublicationRepositpry.AddUpdate(publication);
        //    return uow.SaveChanges() >= 0;
        //}

        public async Task<IEnumerable<PublicationDTO>> GetPublications()
        {
            var publications = await RepositoryScope.PublicationRepository.GetAllPublications();

            return Mapper.Map<IEnumerable<PublicationDTO>>(publications);
        }

        public async Task<PublicationDTO> GetPublicationById(string id)
        {
            var publication = await RepositoryScope.PublicationRepository.GetById(id); // uow.PublicationRepositpry.GetById(id);

            return Mapper.Map<PublicationDTO>(publication);
        }
    }
}
