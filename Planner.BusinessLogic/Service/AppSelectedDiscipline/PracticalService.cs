using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppSelectedDiscipline
{
    public class PracticalService : BaseService, IPracticalService
    {
        public PracticalService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<int> InsertPractical(PracticalDto practicalDto)
        {
            var practical = this.Mapper.Map<Practical>(practicalDto);

            return await this.Uow.PracticalRepository.InsertPractical(practical);
        }
    }
}