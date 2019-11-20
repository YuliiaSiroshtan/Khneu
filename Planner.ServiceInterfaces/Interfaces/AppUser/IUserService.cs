using Planner.Entities.DTO.AppUserDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppUser
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task<IEnumerable<UserDto>> GetUsersByDepartmentId(int id);

        Task DeleteUser(int id);

        Task<UserDto> GetUserById(int id);

        Task<UserDto> GetUserByLogin(string login);

        Task<UserDto> GetUserByLoginAndPassword(string login, string password);

        Task<string> GetUserNameById(int id);

        Task UpdateUser(UserDto userDto);

        Task InsertUser(UserDto userDto);

    }
}
