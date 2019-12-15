using Planner.Entities.Domain.AppUser;
using Planner.Entities.DTO.AppUserDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppUser
{
    public interface IUserEntryLoadPropertyService
    {
        Task<IEnumerable<UserEntryLoadPropertyDto>> GetUserEntryLoadPropertiesByUserId(int id);

        Task<UserEntryLoadProperty> GetUserEntryLoadPropertyById(int id);

        Task<int> InsertUserEntryLoadProperty(UserEntryLoadProperty userEntryLoadProperty);

        Task DeleteUserEntryLoadProperty(int id);
    }
}