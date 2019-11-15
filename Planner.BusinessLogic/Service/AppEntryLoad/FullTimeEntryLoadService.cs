using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppEntryLoad
{
    public class FullTimeEntryLoadService : IFullTimeEntryLoadService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FullTimeEntryLoadService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FullTimeEntryLoadDto>> GetFullTimeEntryLoads()
        {
            var fullTimeEntryLoads = await _uow.FullTimeEntryLoadRepository.GetFullTimeEntryLoads();

            return _mapper.Map<IEnumerable<FullTimeEntryLoadDto>>(fullTimeEntryLoads);
        }

        public async Task DeleteFullTimeEntryLoad(int id)
        {
            await _uow.FullTimeEntryLoadRepository.DeleteFullTimeEntryLoad(id);
        }

        public async Task<FullTimeEntryLoadDto> GetFullTimeEntryLoadById(int id)
        {
            var fullTimeEntryLoad = await _uow.FullTimeEntryLoadRepository.GetFullTimeEntryLoadById(id);

            return _mapper.Map<FullTimeEntryLoadDto>(fullTimeEntryLoad);
        }

        public async Task UpdateFullTimeEntryLoad(FullTimeEntryLoadDto fullTimeEntryLoadDto)
        {
            var fullTimeEntryLoad = _mapper.Map<FullTimeEntryLoad>(fullTimeEntryLoadDto);

            await _uow.FullTimeEntryLoadRepository.UpdateFullTimeEntryLoad(fullTimeEntryLoad);
        }

        public async Task InsertFullTimeEntryLoad(FullTimeEntryLoadDto fullTimeEntryLoadDto)
        {
            var fullTimeEntryLoad = _mapper.Map<FullTimeEntryLoad>(fullTimeEntryLoadDto);

            await _uow.FullTimeEntryLoadRepository.InsertFullTimeEntryLoad(fullTimeEntryLoad);
        }
    }
}
