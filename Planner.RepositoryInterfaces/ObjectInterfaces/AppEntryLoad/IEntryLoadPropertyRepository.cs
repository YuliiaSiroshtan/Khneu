using Planner.Entities.Domain.AppEntryLoad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppEntryLoad
{
    public interface IEntryLoadPropertyRepository
    {
        Task<IEnumerable<EntryLoadsProperty>> GetEntryLoadsProperties();

        Task DeleteEntryLoadsProperty(int id);

        Task<EntryLoadsProperty> GetEntryLoadsPropertyById(int id);

        Task<EntryLoadsProperty> GetEntryLoadsPropertyByName(string name);

        Task UpdateEntryLoadsProperty(EntryLoadsProperty entryLoadsProperty);

        Task<int> InsertEntryLoadsProperty(EntryLoadsProperty entryLoadsProperty);

        Task RecreateTables();
    }
}