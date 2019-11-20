using Planner.Entities.DTO.AppEntryLoadDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppEntryLoad
{
    public interface IEntryLoadPropertyService
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
