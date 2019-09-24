using Planner.ServiceInterfaces.DTO;
using System.Collections.Generic;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(string email);
        UserDTO GetUserById(string userId);
        bool AddOrUpdateUser(UserDTO userDTO);
        IEnumerable<UserListItemDTO> GetAllUsers();
        bool ChangeUserStatus(string userId);
    }
}
