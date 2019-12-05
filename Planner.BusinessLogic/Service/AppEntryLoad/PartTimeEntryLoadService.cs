using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppEntryLoad
{
    public class PartTimeEntryLoadService : BaseService, IPartTimeEntryLoadService
    {
        public PartTimeEntryLoadService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<IEnumerable<PartTimeEntryLoadDto>> GetPartTimeEntryLoads()
        {
            var partTimeEntryLoads = await this.Uow.PartTimeEntryLoadRepository.GetPartTimeEntryLoads();

            return this.Mapper.Map<IEnumerable<PartTimeEntryLoadDto>>(partTimeEntryLoads);
        }

        public async Task<IEnumerable<PartTimeEntryLoadDto>> GetPartTimeEntryLoadsByUserId(int id)
        {
            var partTimeEntryLoads = await this.Uow.PartTimeEntryLoadRepository.GetPartTimeEntryLoadsByUserId(id);

            return this.Mapper.Map<IEnumerable<PartTimeEntryLoadDto>>(partTimeEntryLoads);
        }

        public async Task<PartTimeEntryLoadDto> GetPartTimeEntryLoadById(int id)
        {
            var partTimeEntryLoad = await this.Uow.PartTimeEntryLoadRepository.GetPartTimeEntryLoadById(id);

            return this.Mapper.Map<PartTimeEntryLoadDto>(partTimeEntryLoad);
        }

        public async Task<int> InsertPartTimeEntryLoad(PartTimeEntryLoadDto partTimeEntryLoadDto)
        {
            var partTimeEntryLoad = this.Mapper.Map<PartTimeEntryLoad>(partTimeEntryLoadDto);

            return await this.Uow.PartTimeEntryLoadRepository.InsertPartTimeEntryLoad(partTimeEntryLoad);
        }
    }
}