using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.DTO.AppUserDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppUser
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<RoleDto> GetRoleById(int id)
        {
            var role = await this.Uow.RoleRepository.GetRoleById(id);

            return this.Mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> GetRoleByName(string name)
        {
            var role = await this.Uow.RoleRepository.GetRoleByName(name);

            return this.Mapper.Map<RoleDto>(role);
        }
    }
}