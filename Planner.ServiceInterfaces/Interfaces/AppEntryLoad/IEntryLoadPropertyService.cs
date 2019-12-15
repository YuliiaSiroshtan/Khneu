using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.DTO.AppEntryLoadDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppEntryLoad
{
    public interface IEntryLoadPropertyService
    {
        Task<IEnumerable<EntryLoadsProperty>> GetEntryLoadsProperties();

        Task DeleteEntryLoadsProperty(int id);

        Task<EntryLoadsPropertyDto> GetEntryLoadsPropertyById(int id);

        Task<EntryLoadsPropertyDto> GetEntryLoadsPropertyByName(string name);

        Task UpdateEntryLoadsProperty(EntryLoadsProperty entryLoadsPropertyDto);

        Task InsertEntryLoadsProperty(EntryLoadsProperty entryLoadsProperty);
    }
}