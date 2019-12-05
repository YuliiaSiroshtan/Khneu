using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.DTO.AppUserDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppUser
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await this.Uow.UserRepository.GetUsers();

            return this.Mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByDepartmentId(int id)
        {
            var users = await this.Uow.UserRepository.GetUsersByDepartmentId(id);

            return this.Mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task DeleteUser(int id) => await this.Uow.UserRepository.DeleteUser(id);

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await this.Uow.UserRepository.GetUserById(id);

            return this.Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByLogin(string login)
        {
            var user = await this.Uow.UserRepository.GetUserByLogin(login);

            return this.Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByLoginAndPassword(string login, string password)
        {
            var user = await this.Uow.UserRepository.GetUserByLoginAndPassword(login, password);

            return this.Mapper.Map<UserDto>(user);
        }

        public async Task<string> GetUserNameById(int id) => await this.Uow.UserRepository.GetUserNameById(id);

        public async Task UpdateUser(UserDto userDto)
        {
            var user = this.Mapper.Map<User>(userDto);

            await this.Uow.UserRepository.UpdateUser(user);
        }

        public async Task InsertUser(UserDto userDto)
        {
            var user = this.Mapper.Map<User>(userDto);

            await this.Uow.UserRepository.InsertUser(user);
        }
    }
}