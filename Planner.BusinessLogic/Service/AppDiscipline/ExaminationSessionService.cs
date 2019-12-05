using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppDiscipline
{
    public class ExaminationSessionService : BaseService, IExaminationSessionService
    {
        public ExaminationSessionService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<int> InsertExaminationSession(ExaminationSessionDto examinationSessionDto)
        {
            var examinationSession = this.Mapper.Map<ExaminationSession>(examinationSessionDto);

            return await this.Uow.ExaminationSessionRepository.InsertExaminationSession(examinationSession);
        }
    }
}