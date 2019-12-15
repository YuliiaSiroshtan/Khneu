using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.DTO.AppUserDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppUser
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope, mapper) { }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await this.RepositoryScope.UserRepository.GetUsers();

            return this.Mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByDepartmentId(int id)
        {
            var users = await this.RepositoryScope.UserRepository.GetUsersByDepartmentId(id);

            return this.Mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task DeleteUser(int id) => await this.RepositoryScope.UserRepository.DeleteUser(id);

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await this.RepositoryScope.UserRepository.GetUserById(id);

            return this.Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByLogin(string login)
        {
            var user = await this.RepositoryScope.UserRepository.GetUserByLogin(login);

            return this.Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByLoginAndPassword(string login, string password)
        {
            var user = await this.RepositoryScope.UserRepository.GetUserByLoginAndPassword(login, password);

            return this.Mapper.Map<UserDto>(user);
        }

        public async Task<string> GetUserNameById(int id) =>
            await this.RepositoryScope.UserRepository.GetUserNameById(id);

        public async Task UpdateUser(UserDto userDto)
        {
            var user = this.Mapper.Map<User>(userDto);

            await this.RepositoryScope.UserRepository.UpdateUser(user);
        }
    }
}