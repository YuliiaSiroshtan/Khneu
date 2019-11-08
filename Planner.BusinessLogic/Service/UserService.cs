using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.DTO.AppUserDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _uow.UserRepository.GetUsers();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task DeleteUser(int id)
        {
            await _uow.UserRepository.DeleteUser(id);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _uow.UserRepository.GetUserById(id);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByLogin(string login)
        {
            var user = await _uow.UserRepository.GetUserByLogin(login);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByLoginAndPassword(string login, string password)
        {
            var user = await _uow.UserRepository.GetUserByLoginAndPassword(login, password);

            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateUser(UserDto userDto)
        {
            var user= _mapper.Map<User>(userDto);

            await _uow.UserRepository.UpdateUser(user);
        }

        public async Task InsertUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            await _uow.UserRepository.InsertUser(user);
        }
    }
}
