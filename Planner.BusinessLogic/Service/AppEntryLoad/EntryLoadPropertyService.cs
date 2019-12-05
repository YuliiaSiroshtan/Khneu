using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppEntryLoad
{
    public class EntryLoadPropertyService : BaseService, IEntryLoadPropertyService
    {
        public EntryLoadPropertyService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<IEnumerable<EntryLoadsPropertyDto>> GetEntryLoadsProperties()
        {
            var entryLoadsProperties = await this.Uow.EntryLoadPropertyRepository.GetEntryLoadsProperties();

            return this.Mapper.Map<IEnumerable<EntryLoadsPropertyDto>>(entryLoadsProperties);
        }

        public async Task DeleteEntryLoadsProperty(int id) =>
            await this.Uow.EntryLoadPropertyRepository.DeleteEntryLoadsProperty(id);

        public async Task<EntryLoadsPropertyDto> GetEntryLoadsPropertyById(int id)
        {
            var entryLoadsProperty = await this.Uow.EntryLoadPropertyRepository.GetEntryLoadsPropertyById(id);

            return this.Mapper.Map<EntryLoadsPropertyDto>(entryLoadsProperty);
        }

        public async Task<EntryLoadsPropertyDto> GetEntryLoadsPropertyByName(string name)
        {
            var entryLoadsProperty = await this.Uow.EntryLoadPropertyRepository.GetEntryLoadsPropertyByName(name);

            return this.Mapper.Map<EntryLoadsPropertyDto>(entryLoadsProperty);
        }

        public async Task UpdateEntryLoadsProperty(EntryLoadsPropertyDto entryLoadsPropertyDto)
        {
            var entryLoadsProperty = this.Mapper.Map<EntryLoadsProperty>(entryLoadsPropertyDto);

            await this.Uow.EntryLoadPropertyRepository.UpdateEntryLoadsProperty(entryLoadsProperty);
        }

        public async Task InsertEntryLoadsProperty(EntryLoadsPropertyDto entryLoadsPropertyDto)
        {
            var entryLoadsProperty = this.Mapper.Map<EntryLoadsProperty>(entryLoadsPropertyDto);

            await this.Uow.EntryLoadPropertyRepository.InsertEntryLoadsProperty(entryLoadsProperty);
        }

        public async Task RecreateTables() => await this.Uow.EntryLoadPropertyRepository.RecreateTables();
    }
}