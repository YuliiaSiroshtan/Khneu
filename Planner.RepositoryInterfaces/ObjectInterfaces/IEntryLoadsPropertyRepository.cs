using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppEntryLoad;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IEntryLoadsPropertyRepository
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
