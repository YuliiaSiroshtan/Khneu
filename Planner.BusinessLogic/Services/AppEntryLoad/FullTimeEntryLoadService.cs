using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppEntryLoad
{
    public class FullTimeEntryLoadService : BaseService, IFullTimeEntryLoadService
    {
        public FullTimeEntryLoadService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope,
            mapper) { }

        public async Task<IEnumerable<FullTimeEntryLoad>> GetFullTimeEntryLoads()
            => await this.RepositoryScope.FullTimeEntryLoadRepository.GetFullTimeEntryLoads();

        public async Task<IEnumerable<FullTimeEntryLoadDto>> GetFullTimeEntryLoadsByUserId(int id)
        {
            var entryLoads = await this.RepositoryScope.FullTimeEntryLoadRepository.GetFullTimeEntryLoadsByUserId(id);

            return this.Mapper.Map<IEnumerable<FullTimeEntryLoadDto>>(entryLoads);
        }

        public async Task<FullTimeEntryLoad> GetFullTimeEntryLoadById(int id)
            => await this.RepositoryScope.FullTimeEntryLoadRepository.GetFullTimeEntryLoadById(id);

        public async Task InsertFullTimeEntryLoad(FullTimeEntryLoad fullTimeEntryLoad)
            => await this.RepositoryScope.FullTimeEntryLoadRepository.InsertFullTimeEntryLoad(fullTimeEntryLoad);
    }
}