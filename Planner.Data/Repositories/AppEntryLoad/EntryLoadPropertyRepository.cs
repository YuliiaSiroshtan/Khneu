using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.RepositoryInterfaces.Interfaces.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppEntryLoad
{
    public class EntryLoadPropertyRepository : GenericRepository<EntryLoadsProperty>, IEntryLoadPropertyRepository
    {
        public EntryLoadPropertyRepository(string connectionString, string tableName) : base(connectionString,
            tableName) { }


        public async Task<IEnumerable<EntryLoadsProperty>> GetEntryLoadsProperties() => await this.GetEntities();


        public async Task DeleteEntryLoadsProperty(int id) => await this.DeleteEntity(id);


        public async Task<EntryLoadsProperty> GetEntryLoadsPropertyById(int id) => await this.GetEntityById(id);


        public async Task<EntryLoadsProperty> GetEntryLoadsPropertyByName(string name) =>
            await this.GetEntityByName(name);


        public async Task UpdateEntryLoadsProperty(EntryLoadsProperty entryLoadsProperty) =>
            await this.Update(entryLoadsProperty);

        public async Task<int> InsertEntryLoadsProperty(EntryLoadsProperty entryLoadsProperty) =>
            await this.Insert(entryLoadsProperty);
    }
}