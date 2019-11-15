using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppEntryLoad
{
    public class PartTimeEntryLoadService : IPartTimeEntryLoadService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PartTimeEntryLoadService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PartTimeEntryLoadDto>> GetPartTimeEntryLoads()
        {
            var partTimeEntryLoads = await _uow.PartTimeEntryLoadRepository.GetPartTimeEntryLoads();

            return _mapper.Map<IEnumerable<PartTimeEntryLoadDto>>(partTimeEntryLoads);
        }

        public async Task DeletePartTimeEntryLoad(int id)
        {
            await _uow.PartTimeEntryLoadRepository.DeletePartTimeEntryLoad(id);
        }

        public async Task<PartTimeEntryLoadDto> GetPartTimeEntryLoadById(int id)
        {
            var partTimeEntryLoad = await _uow.PartTimeEntryLoadRepository.GetPartTimeEntryLoadById(id);

            return _mapper.Map<PartTimeEntryLoadDto>(partTimeEntryLoad);
        }

        public async Task UpdatePartTimeEntryLoad(PartTimeEntryLoadDto partTimeEntryLoadDto)
        {
            var partTimeEntryLoad = _mapper.Map<PartTimeEntryLoad>(partTimeEntryLoadDto);

            await _uow.PartTimeEntryLoadRepository.UpdatePartTimeEntryLoad(partTimeEntryLoad);
        }

        public async Task<int> InsertPartTimeEntryLoad(PartTimeEntryLoadDto partTimeEntryLoadDto)
        {
            var partTimeEntryLoad = _mapper.Map<PartTimeEntryLoad>(partTimeEntryLoadDto);

            return await _uow.PartTimeEntryLoadRepository.InsertPartTimeEntryLoad(partTimeEntryLoad);
        }
    }
}
