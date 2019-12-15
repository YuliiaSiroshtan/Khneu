using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppSelectedDiscipline
{
    public class PracticalService : BaseService, IPracticalService
    {
        public PracticalService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope, mapper) { }

        public async Task<int> InsertPractical(PracticalDto practicalDto)
        {
            var practical = this.Mapper.Map<Practical>(practicalDto);

            return await this.RepositoryScope.PracticalRepository.InsertPractical(practical);
        }
    }
}