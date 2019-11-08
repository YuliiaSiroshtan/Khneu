using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppUser;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task DeleteUser(int id);

        Task<User> GetUserById(int id);

        Task<User> GetUserByLogin(string login);

        Task<User> GetUserByLoginAndPassword(string login, string password);

        Task UpdateUser(User user);

        Task<int> InsertUser(User user);
    }
}
