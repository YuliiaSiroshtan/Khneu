using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IEntryLoadsPropertyService
    {
        Task<IEnumerable<EntryLoadsPropertyDto>> GetEntryLoadsProperties();

        Task DeleteEntryLoadsProperty(int id);

        Task<EntryLoadsPropertyDto> GetEntryLoadsPropertyById(int id);

        Task<EntryLoadsPropertyDto> GetEntryLoadsPropertyByName(string name);

        Task UpdateEntryLoadsProperty(EntryLoadsPropertyDto entryLoadsPropertyDto);

        Task InsertEntryLoadsProperty(EntryLoadsPropertyDto entryLoadsPropertyDto);

        Task RecreateTables();
    }
}
