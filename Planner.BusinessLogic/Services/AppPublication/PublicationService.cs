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

        public async Task UpdatePublication(PublicationDTO publicationDTO)
        {
            Publication publication = Mapper.Map<Publication>(publicationDTO);

            await RepositoryScope.PublicationRepository.UpdatePublication(publication);
        }


        public async Task<IEnumerable<PublicationDTO>> GetPublications(string userLogin)
        {
            var publications = await RepositoryScope.PublicationRepository.GetAllPublications(userLogin);

            return Mapper.Map<IEnumerable<PublicationDTO>>(publications);
        }

        public async Task<PublicationDTO> GetPublicationById(string id)
        {
            var publication = await RepositoryScope.PublicationRepository.GetById(id);

            return Mapper.Map<PublicationDTO>(publication);
        }
    }
}
