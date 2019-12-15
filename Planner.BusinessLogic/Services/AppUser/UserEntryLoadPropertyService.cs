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
    public class UserEntryLoadPropertyService : BaseService, IUserEntryLoadPropertyService
    {
        public UserEntryLoadPropertyService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope,
            mapper) { }

        public async Task<IEnumerable<UserEntryLoadPropertyDto>> GetUserEntryLoadPropertiesByUserId(int id)
        {
            var userEntryLoadsProperties =
                await this.RepositoryScope.UserEntryLoadPropertyRepository.GetUserEntryLoadPropertiesByUserId(id);

            return this.Mapper.Map<IEnumerable<UserEntryLoadPropertyDto>>(userEntryLoadsProperties);
        }

        public async Task<UserEntryLoadProperty> GetUserEntryLoadPropertyById(int id)
            => await this.RepositoryScope.UserEntryLoadPropertyRepository.GetUserEntryLoadPropertyById(id);

        public async Task<int> InsertUserEntryLoadProperty(UserEntryLoadProperty userEntryLoadProperty) =>
            await this.RepositoryScope.UserEntryLoadPropertyRepository.InsertUserEntryLoadProperty(
                userEntryLoadProperty);

        public async Task DeleteUserEntryLoadProperty(int id) =>
            await this.RepositoryScope.UserEntryLoadPropertyRepository.DeleteUserEntryLoadProperty(id);
    }
}