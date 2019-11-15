using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppEntryLoad
{
    public class EntryLoadsPropertyService : IEntryLoadsPropertyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EntryLoadsPropertyService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<IEnumerable<EntryLoadsPropertyDto>> GetEntryLoadsProperties()
        {
            var entryLoadsProperties = await _uow.EntryLoadsPropertyRepository.GetEntryLoadsProperties();

            return _mapper.Map<IEnumerable<EntryLoadsPropertyDto>>(entryLoadsProperties);
        }

        public async Task DeleteEntryLoadsProperty(int id)
        {
            await _uow.EntryLoadsPropertyRepository.DeleteEntryLoadsProperty(id);
        }

        public async Task<EntryLoadsPropertyDto> GetEntryLoadsPropertyById(int id)
        {
            var entryLoadsProperty = await _uow.EntryLoadsPropertyRepository.GetEntryLoadsPropertyById(id);

            return _mapper.Map<EntryLoadsPropertyDto>(entryLoadsProperty);
        }

        public async Task<EntryLoadsPropertyDto> GetEntryLoadsPropertyByName(string name)
        {
            var entryLoadsProperty = await _uow.EntryLoadsPropertyRepository.GetEntryLoadsPropertyByName(name);

            return _mapper.Map<EntryLoadsPropertyDto>(entryLoadsProperty);
        }

        public async Task UpdateEntryLoadsProperty(EntryLoadsPropertyDto entryLoadsPropertyDto)
        {
            var entryLoadsProperty = _mapper.Map<EntryLoadsProperty>(entryLoadsPropertyDto);

            await _uow.EntryLoadsPropertyRepository.UpdateEntryLoadsProperty(entryLoadsProperty);
        }

        public async Task InsertEntryLoadsProperty(EntryLoadsPropertyDto entryLoadsPropertyDto)
        {
            var entryLoadsProperty = _mapper.Map<EntryLoadsProperty>(entryLoadsPropertyDto);

            await _uow.EntryLoadsPropertyRepository.InsertEntryLoadsProperty(entryLoadsProperty);
        }

        public async Task RecreateTables()
        {
            await _uow.EntryLoadsPropertyRepository.RecreateTables();
        }
    }
}
