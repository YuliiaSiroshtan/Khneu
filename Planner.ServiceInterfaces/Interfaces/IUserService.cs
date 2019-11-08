using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO.AppUserDto;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task DeleteUser(int id);

        Task<UserDto> GetUserById(int id);

        Task<UserDto> GetUserByLogin(string login);

        Task<UserDto> GetUserByLoginAndPassword(string login, string password);

        Task UpdateUser(UserDto userDto);

        Task InsertUser(UserDto userDto);
    }
}
