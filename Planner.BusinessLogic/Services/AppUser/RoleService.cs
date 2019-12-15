using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.DTO.AppUserDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppUser
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope, mapper) { }

        public async Task<RoleDto> GetRoleById(int id)
        {
            var role = await this.RepositoryScope.RoleRepository.GetRoleById(id);

            return this.Mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> GetRoleByName(string name)
        {
            var role = await this.RepositoryScope.RoleRepository.GetRoleByName(name);

            return this.Mapper.Map<RoleDto>(role);
        }
    }
}