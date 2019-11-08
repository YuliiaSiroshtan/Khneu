using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
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

        public async Task<IEnumerable<ExaminationSessionDto>> GetExaminationSessions()
        {
            var examinationSessions = await _uow.ExaminationSessionRepository.GetExaminationSessions();

            return _mapper.Map<IEnumerable<ExaminationSessionDto>>(examinationSessions);
        }

        public async Task DeleteExaminationSession(int id)
        {
            await _uow.ExaminationSessionRepository.DeleteExaminationSession(id);
        }

        public async Task<ExaminationSessionDto> GetExaminationSessionById(int id)
        {
            var examinationSession = await _uow.ExaminationSessionRepository.GetExaminationSessionById(id);

            return _mapper.Map<ExaminationSessionDto>(examinationSession);
        }

        public async Task UpdateExaminationSession(ExaminationSessionDto examinationSessionDto)
        {
            var examinationSession = _mapper.Map<ExaminationSession>(examinationSessionDto);

            await _uow.ExaminationSessionRepository.UpdateExaminationSession(examinationSession);
        }

        public async Task<int> InsertExaminationSession(ExaminationSessionDto examinationSessionDto)
        {
            var examinationSession = _mapper.Map<ExaminationSession>(examinationSessionDto);

            return await _uow.ExaminationSessionRepository.InsertExaminationSession(examinationSession);
        }
    }
}
