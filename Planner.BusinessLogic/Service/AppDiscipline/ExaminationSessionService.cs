using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppDiscipline
{
    public class ExaminationSessionService : IExaminationSessionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ExaminationSessionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<int> InsertExaminationSession(ExaminationSessionDto examinationSessionDto)
        {
            var examinationSession = _mapper.Map<ExaminationSession>(examinationSessionDto);

            return await _uow.ExaminationSessionRepository.InsertExaminationSession(examinationSession);
        }
    }
}
