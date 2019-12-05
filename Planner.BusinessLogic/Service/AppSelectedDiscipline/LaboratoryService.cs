using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppSelectedDiscipline
{
    public class LaboratoryService : BaseService, ILaboratoryService
    {
        public LaboratoryService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<int> InsertLaboratory(LaboratoryDto laboratoryDto)
        {
            var laboratory = this.Mapper.Map<Laboratory>(laboratoryDto);

            return await this.Uow.LaboratoryRepository.InsertLaboratory(laboratory);
        }
    }
}