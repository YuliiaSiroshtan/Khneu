using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppDiscipline
{
    public class ConstituentSessionService : IConstituentSessionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ConstituentSessionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConstituentSessionDto>> GetConstituentSessions()
        {
            var constituentSessions = await _uow.ConstituentSessionRepository.GetConstituentSessions();

            return _mapper.Map<IEnumerable<ConstituentSessionDto>>(constituentSessions);
        }

        public async Task DeleteConstituentSession(int id)
        {
            await _uow.ConstituentSessionRepository.DeleteConstituentSession(id);
        }

        public async Task<ConstituentSessionDto> GetConstituentSessionById(int id)
        {
            var constituentSession = await _uow.ConstituentSessionRepository.GetConstituentSessionById(id);

            return _mapper.Map<ConstituentSessionDto>(constituentSession);
        }

        public async Task UpdateConstituentSession(ConstituentSessionDto constituentSessionDto)
        {
            var constituentSession = _mapper.Map<ConstituentSession>(constituentSessionDto);

            await _uow.ConstituentSessionRepository.UpdateConstituentSession(constituentSession);
        }

        public async Task<int> InsertConstituentSession(ConstituentSessionDto constituentSessionDto)
        {
            var constituentSession = _mapper.Map<ConstituentSession>(constituentSessionDto);

            return await _uow.ConstituentSessionRepository.InsertConstituentSession(constituentSession);
        }
    }
}

