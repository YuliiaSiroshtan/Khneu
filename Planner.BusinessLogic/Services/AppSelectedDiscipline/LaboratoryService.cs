using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppSelectedDiscipline
{
    public class LaboratoryService : BaseService, ILaboratoryService
    {
        public LaboratoryService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope, mapper) { }

        public async Task<int> InsertLaboratory(LaboratoryDto laboratoryDto)
        {
            var laboratory = this.Mapper.Map<Laboratory>(laboratoryDto);

            return await this.RepositoryScope.LaboratoryRepository.InsertLaboratory(laboratory);
        }
    }
}