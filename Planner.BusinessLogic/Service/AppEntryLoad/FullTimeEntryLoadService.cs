using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppEntryLoad
{
    public class FullTimeEntryLoadService : BaseService, IFullTimeEntryLoadService
    {
        public FullTimeEntryLoadService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<IEnumerable<FullTimeEntryLoadDto>> GetFullTimeEntryLoads()
        {
            var fullTimeEntryLoads = await this.Uow.FullTimeEntryLoadRepository.GetFullTimeEntryLoads();

            return this.Mapper.Map<IEnumerable<FullTimeEntryLoadDto>>(fullTimeEntryLoads);
        }

        public async Task<IEnumerable<FullTimeEntryLoadDto>> GetFullTimeEntryLoadsByUserId(int id)
        {
            var fullTimeEntryLoads = await this.Uow.FullTimeEntryLoadRepository.GetFullTimeEntryLoadsByUserId(id);

            return this.Mapper.Map<IEnumerable<FullTimeEntryLoadDto>>(fullTimeEntryLoads);
        }

        public async Task<FullTimeEntryLoadDto> GetFullTimeEntryLoadById(int id)
        {
            var fullTimeEntryLoad = await this.Uow.FullTimeEntryLoadRepository.GetFullTimeEntryLoadById(id);

            return this.Mapper.Map<FullTimeEntryLoadDto>(fullTimeEntryLoad);
        }

        public async Task InsertFullTimeEntryLoad(FullTimeEntryLoadDto fullTimeEntryLoadDto)
        {
            var fullTimeEntryLoad = this.Mapper.Map<FullTimeEntryLoad>(fullTimeEntryLoadDto);

            await this.Uow.FullTimeEntryLoadRepository.InsertFullTimeEntryLoad(fullTimeEntryLoad);
        }
    }
}