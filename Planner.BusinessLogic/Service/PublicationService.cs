using AutoMapper;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.DTO.Publication;
using Planner.ServiceInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service
{
    public class PublicationService : IPublicationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PublicationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NmbdDTO>> GetAllNmbds()
        {
            var nmbds = _mapper.Map<IEnumerable<NmbdDTO>>(await _uow.NMBDRepository.GetAllNMBD());

            return nmbds;
        }

        public async Task<bool> UpdatePublication(PublicationAddEditDTO publicationDTO, string userName)
        {
            var user = await _uow.UserRepository.GetByUserName(userName);

            Publication existingPublication = null;
            var publication = _mapper.Map<Publication>(publicationDTO);

            if (!string.IsNullOrEmpty(publicationDTO.PublicationId))
            {
                existingPublication = await _uow.PublicationRepository.GetById(publicationDTO.PublicationId);
                publication.PublicationId = publicationDTO.PublicationId;
            }

            publication.PublishedAt = publicationDTO.PublishedAt.ToUniversalTime();
            publication.IsPublished = true;
            publication.OwnerId = user.ApplicationUserId;

            var publicationUsers = publicationDTO.CollaboratorsIds
                .Select(item => new PublicationUser
                { ApplicationUserId = item, PageQuantity = publicationDTO.Pages / publicationDTO.CollaboratorsIds.Count }).ToList();

            publication.PublicationUsers = publicationUsers;

            _uow.PublicationRepository.AddUpdate(publication);

            return await _uow.SaveChanges() >= 0;
        }

        public async Task<IEnumerable<PublicationDTO>> GetPublications()
        {
            var publications = await _uow.PublicationRepository.GetAllPublications();

            return _mapper.Map<IEnumerable<PublicationDTO>>(publications);
        }
        public async Task<PublicationDTO> GetPublicationById(String id)
        {
            var publication = await _uow.PublicationRepository.GetById(id);

            return _mapper.Map<PublicationDTO>(publication);
        }
    }
}
