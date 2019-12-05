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
    public class UserEntryLoadPropertyService : BaseService, IUserEntryLoadPropertyService
    {
        public UserEntryLoadPropertyService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<IEnumerable<UserEntryLoadPropertyDto>> GetUserEntryLoadPropertiesByUserId(int id)
        {
            var userEntryLoadsProperties =
                await this.Uow.UserEntryLoadPropertyRepository.GetUserEntryLoadPropertiesByUserId(id);

            return this.Mapper.Map<IEnumerable<UserEntryLoadPropertyDto>>(userEntryLoadsProperties);
        }

        public async Task<UserEntryLoadPropertyDto> GetUserEntryLoadPropertyById(int id)
        {
            var userEntryLoadsProperties =
                await this.Uow.UserEntryLoadPropertyRepository.GetUserEntryLoadPropertyById(id);

            return this.Mapper.Map<UserEntryLoadPropertyDto>(userEntryLoadsProperties);
        }

        public async Task<int> InsertUserEntryLoadProperty(UserEntryLoadPropertyDto userEntryLoadPropertyDto)
        {
            var userEntryLoadsProperty = this.Mapper.Map<UserEntryLoadProperty>(userEntryLoadPropertyDto);

            return await this.Uow.UserEntryLoadPropertyRepository.InsertUserEntryLoadProperty(userEntryLoadsProperty);
        }

        public async Task DeleteUserEntryLoadProperty(int id) =>
            await this.Uow.UserEntryLoadPropertyRepository.DeleteUserEntryLoadProperty(id);
    }
}