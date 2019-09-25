using Planner.ServiceInterfaces.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(string email);
        Task<UserDTO> GetUserById(string userId);
        Task<bool> AddOrUpdateUser(UserDTO userDTO);
        Task<IEnumerable<UserListItemDTO>> GetAllUsers();
        Task<bool> ChangeUserStatus(string userId);
    }
}
