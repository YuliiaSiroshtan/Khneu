using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppEntryLoad
{
    public class EntryLoadPropertyService : BaseService, IEntryLoadPropertyService
    {
        public EntryLoadPropertyService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope,
            mapper) { }

        public async Task<IEnumerable<EntryLoadsProperty>> GetEntryLoadsProperties()
            => await this.RepositoryScope.EntryLoadPropertyRepository.GetEntryLoadsProperties();

        public async Task DeleteEntryLoadsProperty(int id) =>
            await this.RepositoryScope.EntryLoadPropertyRepository.DeleteEntryLoadsProperty(id);

        public async Task<EntryLoadsPropertyDto> GetEntryLoadsPropertyById(int id)
        {
            var entryLoadsProperty =
                await this.RepositoryScope.EntryLoadPropertyRepository.GetEntryLoadsPropertyById(id);

            return this.Mapper.Map<EntryLoadsPropertyDto>(entryLoadsProperty);
        }

        public async Task<EntryLoadsPropertyDto> GetEntryLoadsPropertyByName(string name)
        {
            var entryLoadsProperty =
                await this.RepositoryScope.EntryLoadPropertyRepository.GetEntryLoadsPropertyByName(name);

            return this.Mapper.Map<EntryLoadsPropertyDto>(entryLoadsProperty);
        }

        public async Task UpdateEntryLoadsProperty(EntryLoadsProperty entryLoadsProperty)
            => await this.RepositoryScope.EntryLoadPropertyRepository.UpdateEntryLoadsProperty(entryLoadsProperty);

        public async Task InsertEntryLoadsProperty(EntryLoadsProperty entryLoadsProperty)
            => await this.RepositoryScope.EntryLoadPropertyRepository.InsertEntryLoadsProperty(entryLoadsProperty);
    }
}