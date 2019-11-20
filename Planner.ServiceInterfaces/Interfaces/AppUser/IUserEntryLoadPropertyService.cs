using Planner.Entities.DTO.AppUserDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppUser
{
    public interface IUserEntryLoadPropertyService
    {
        Task<IEnumerable<UserEntryLoadPropertyDto>> GetUserEntryLoadPropertiesByUserId(int id);

        Task<UserEntryLoadPropertyDto> GetUserEntryLoadPropertyById(int id);

        Task<int> InsertUserEntryLoadProperty(UserEntryLoadPropertyDto userEntryLoadPropertyDto);

        Task DeleteUserEntryLoadProperty(int id);
    }
}
