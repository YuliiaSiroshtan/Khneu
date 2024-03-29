﻿using Planner.Entities.Domain.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppUser
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<IEnumerable<User>> GetUsersByDepartmentId(int id);

        Task DeleteUser(int id);

        Task<User> GetUserById(int id);

        Task<User> GetUserByLogin(string login);

        Task<User> GetUserByLoginAndPassword(string login, string password);

        Task<string> GetUserNameById(int id);

        Task<int> GetLdapIdByLogin(string login);

        Task<int> GetDepartmentIdByLogin(string login);

        Task UpdateUser(User user);
    }
}