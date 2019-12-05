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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ConstituentSessionService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public async Task<int> InsertConstituentSession(ConstituentSessionDto constituentSessionDto)
        {
            var constituentSession = this._mapper.Map<ConstituentSession>(constituentSessionDto);

            return await this._uow.ConstituentSessionRepository.InsertConstituentSession(constituentSession);
        }
    }
}