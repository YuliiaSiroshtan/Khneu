using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppEntryLoad
{
    public class PartTimeEntryLoadService : BaseService, IPartTimeEntryLoadService
    {
        public PartTimeEntryLoadService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope,
            mapper) { }

        public async Task<IEnumerable<PartTimeEntryLoad>> GetPartTimeEntryLoads()
            => await this.RepositoryScope.PartTimeEntryLoadRepository.GetPartTimeEntryLoads();

        public async Task<IEnumerable<PartTimeEntryLoadDto>> GetPartTimeEntryLoadsByUserId(int id)
        {
            var entryLoads = await this.RepositoryScope.PartTimeEntryLoadRepository.GetPartTimeEntryLoadsByUserId(id);

            return this.Mapper.Map<IEnumerable<PartTimeEntryLoadDto>>(entryLoads);
        }

        public async Task<PartTimeEntryLoad> GetPartTimeEntryLoadById(int id)
            => await this.RepositoryScope.PartTimeEntryLoadRepository.GetPartTimeEntryLoadById(id);

        public async Task<int> InsertPartTimeEntryLoad(PartTimeEntryLoad partTimeEntryLoad)
            => await this.RepositoryScope.PartTimeEntryLoadRepository.InsertPartTimeEntryLoad(partTimeEntryLoad);
    }
}