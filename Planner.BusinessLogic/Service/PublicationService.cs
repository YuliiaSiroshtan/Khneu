using AutoMapper;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.ServiceInterfaces.DTO;
using Planner.Entities.Domain;
using Planner.ServiceInterfaces.DTO.Publication;
using System.Linq;

namespace Planner.BusinessLogic.Service
{
    public class PublicationService: IPublicationService
    {
        private IUnitOfWork uow;
        private readonly IMapper _mapper;

        public PublicationService(IUnitOfWork _uow, IMapper mapper)
        {
            uow = _uow;
            _mapper = mapper;
        }

        public IEnumerable<NmbdDTO> GetAllNmbds()
        {
            IEnumerable<NmbdDTO> nmbds = _mapper.Map<IEnumerable<NmbdDTO>>( uow.NMBDRepository.GetAllNMBD());
            return nmbds;
        }

        public Boolean UpdatePublication(PublicationAddEditDTO publicationDTO, String userName)
        {
            ApplicationUser user = uow.UserRepository.GetByUserName(userName);
            //NMBD nmbd = uow.NMBDRepository.GetById(publicationDTO.NMBDId);
            Publication existingPublication = null;
            Publication publication = _mapper.Map<Publication>(publicationDTO);
            if (!String.IsNullOrEmpty(publicationDTO.PublicationId))
            {
                existingPublication = uow.PublicationRepositpry.GetById(publicationDTO.PublicationId);
                publication.PublicationId = publicationDTO.PublicationId;
            }

            publication.PublishedAt = publicationDTO.PublishedAt.ToUniversalTime();
            publication.IsPublished = true;
            publication.OwnerId = user.ApplicationUserId;
            List<PublicationUser> publicationUsers = new List<PublicationUser>();

            foreach (var item in publicationDTO.CollaboratorsIds)
            {
                publicationUsers.Add(new PublicationUser
                {
                    ApplicationUserId = item,
                    PageQuantity = publicationDTO.Pages / publicationDTO.CollaboratorsIds.Count

                });
            }

            //PublicationNMBD publicationNMBD = new PublicationNMBD()
            //{

            //}

            publication.PublicationUsers = publicationUsers;



            uow.PublicationRepositpry.AddUpdate(publication);
            return uow.SaveChanges() >= 0;
        }

        public IEnumerable<PublicationDTO> GetPublications()
        {
            IEnumerable<Publication> publications = uow.PublicationRepositpry.GetAllPublications();

            return _mapper.Map<IEnumerable<PublicationDTO>>(publications);
        }
        public PublicationDTO GetPublicationById(String id)
        {
            Publication publication = uow.PublicationRepositpry.GetById(id);

            return _mapper.Map<PublicationDTO>(publication);
        }
    }
}
