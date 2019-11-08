using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.DTO.AppUserDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDto>> GetRoles()
        {
            var roles = await _uow.RoleRepository.GetRoles();

            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task DeleteRole(int id) => await _uow.RoleRepository.DeleteRole(id);

        public async Task<RoleDto> GetRoleById(int id)
        {
            var role = await _uow.RoleRepository.GetRoleById(id);

            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> GetRoleByName(string name)
        {
            var role = await _uow.RoleRepository.GetRoleByName(name);

            return _mapper.Map<RoleDto>(role);
        }

        public async Task UpdateRole(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);

            await _uow.RoleRepository.UpdateRole(role);
        }

        public async Task<int> InsertRole(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);

            return await _uow.RoleRepository.InsertRole(role);
        }
    }
}
