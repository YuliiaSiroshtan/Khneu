using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppDiscipline
{
    public class ExaminationSessionService : BaseService, IExaminationSessionService
    {
        public ExaminationSessionService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope,
            mapper) { }

        public async Task<int> InsertExaminationSession(ExaminationSessionDto examinationSessionDto)
        {
            var examinationSession = this.Mapper.Map<ExaminationSession>(examinationSessionDto);

            return await this.RepositoryScope.ExaminationSessionRepository.InsertExaminationSession(examinationSession);
        }
    }
}