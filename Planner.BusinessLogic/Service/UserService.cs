using AutoMapper;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;

        public UserService(IUnitOfWork uow, IMapper mapper, ISecurityService securityService)
        {
            _uow = uow;
            _mapper = mapper;
            _securityService = securityService;
        }

        public async Task<UserDTO> GetUser(string email)
        {
            var user = await _uow.UserRepository.GetByUserName(email);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserById(string userId)
        {
            var user = await _uow.UserRepository.GetByUserId(userId);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IEnumerable<UserListItemDTO>> GetAllUsers()
        {
            var users = await _uow.UserRepository.GetUsers();

            return _mapper.Map<IEnumerable<UserListItemDTO>>(users);
        }

        public async Task<bool> ChangeUserStatus(string userId)
        {
            var user = await _uow.UserRepository.GetByUserId(userId);
            user.IsActive = !user.IsActive;
            _uow.UserRepository.UpdateUser(user);

            return await _uow.SaveChanges() >= 0;
        }

        public async Task<bool> AddOrUpdateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<ApplicationUser>(userDTO);
            if (!string.IsNullOrEmpty(userDTO.ApplicationUserId))
            {
                var existingUser = await _uow.UserRepository.GetByUserName(userDTO.Email);
                user.PasswordHash = existingUser.PasswordHash;
                user.IsActive = user.IsActive;
            }
            else
            {
                user.PasswordHash =  _securityService.GetSha256Hash(userDTO.Password);
                user.IsActive = true;
            }

            var role = await _uow.RoleRepository.GetRoleByName(userDTO.RoleName);
            if (role != null)
            {
                user.Role = role;
            }

            _uow.UserRepository.UpdateUser(user);

            return await _uow.SaveChanges() >= 0;
        }

    }
}
