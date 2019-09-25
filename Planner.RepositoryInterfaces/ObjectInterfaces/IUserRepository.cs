using Planner.Entities.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetByUserName(string userName);
        Task<ApplicationUser>  GetUser(string userName, string password);
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetByUserId(string userId);
        void UpdateUser(ApplicationUser user);
    }
}
