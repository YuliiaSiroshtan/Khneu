using AutoMapper;
using Planner.Entities.DTO.AppUserDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppUser
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
    }
}
