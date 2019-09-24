using AutoMapper;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.Interfaces;
using System;
using System.Collections.Generic;

namespace Planner.BusinessLogic.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork uow;
        private readonly IMapper _mapper;
        private ISecurityService _securityService;

        public UserService(IUnitOfWork _uow, IMapper mapper, ISecurityService securityService)
        {
            uow = _uow;
            _mapper = mapper;
            _securityService = securityService;
        }

        public UserDTO GetUser(String email)
        {
            ApplicationUser user = uow.UserRepository.GetByUserName(email);
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO GetUserById(String userId)
        {
            ApplicationUser user = uow.UserRepository.GetByUserId(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<UserListItemDTO> GetAllUsers()
        {
            IEnumerable<ApplicationUser> users = uow.UserRepository.GetUsers();
            return _mapper.Map<IEnumerable<UserListItemDTO>>(users);
        }

        public Boolean ChangeUserStatus(String userId)
        {
            ApplicationUser user = uow.UserRepository.GetByUserId(userId);
            user.IsActive = !user.IsActive;
            uow.UserRepository.UpdateUser(user);

            return uow.SaveChanges() >= 0;
        }

        public Boolean AddOrUpdateUser(UserDTO userDTO)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(userDTO);
            ApplicationUser existingUser;
            if (!String.IsNullOrEmpty(userDTO.ApplicationUserId)) {
                existingUser = uow.UserRepository.GetByUserName(userDTO.Email);
                user.PasswordHash = existingUser.PasswordHash;
                user.IsActive = user.IsActive;
            }
            else
            {
                user.PasswordHash = _securityService.GetSha256Hash(userDTO.Password);
                user.IsActive = true;
            }

            Role role = uow.RoleRepository.GetRoleByName(userDTO.RoleName);
            if (role != null)
            {
                user.Role = role;
            }

            uow.UserRepository.UpdateUser(user);

            return uow.SaveChanges() >= 0;
        }

    }
}
