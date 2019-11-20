using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
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

        public async Task<int> InsertConstituentSession(ConstituentSessionDto constituentSessionDto)
        {
            var constituentSession = _mapper.Map<ConstituentSession>(constituentSessionDto);

            return await _uow.ConstituentSessionRepository.InsertConstituentSession(constituentSession);
        }
    }
}

