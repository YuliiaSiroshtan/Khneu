using Planner.Entities.Domain.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppUser
{
    public interface IUserEntryLoadPropertyRepository
    {
        Task<IEnumerable<UserEntryLoadProperty>> GetUserEntryLoadPropertiesByUserId(int id);

        Task<UserEntryLoadProperty> GetUserEntryLoadPropertyById(int id);

        Task<int> InsertUserEntryLoadProperty(UserEntryLoadProperty userEntryLoadProperty);

        Task DeleteUserEntryLoadProperty(int id);
    }
}