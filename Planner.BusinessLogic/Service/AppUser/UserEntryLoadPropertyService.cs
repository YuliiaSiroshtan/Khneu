using AutoMapper;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.DTO.AppUserDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppUser
{
    public class UserEntryLoadPropertyService : IUserEntryLoadPropertyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserEntryLoadPropertyService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserEntryLoadPropertyDto>> GetUserEntryLoadPropertiesByUserId(int id)
        {
            var userEntryLoadsProperties = await _uow.UserEntryLoadPropertyRepository.GetUserEntryLoadPropertiesByUserId(id);

            return _mapper.Map<IEnumerable<UserEntryLoadPropertyDto>>(userEntryLoadsProperties);
        }

        public async Task<UserEntryLoadPropertyDto> GetUserEntryLoadPropertyById(int id)
        {
            var userEntryLoadsProperties = await _uow.UserEntryLoadPropertyRepository.GetUserEntryLoadPropertyById(id);

            return _mapper.Map<UserEntryLoadPropertyDto>(userEntryLoadsProperties);
        }

        public async Task<int> InsertUserEntryLoadProperty(UserEntryLoadPropertyDto userEntryLoadPropertyDto)
        {
            var userEntryLoadsProperty = _mapper.Map<UserEntryLoadProperty>(userEntryLoadPropertyDto);

            return await _uow.UserEntryLoadPropertyRepository.InsertUserEntryLoadProperty(userEntryLoadsProperty);
        }

        public async Task DeleteUserEntryLoadProperty(int id) =>
            await _uow.UserEntryLoadPropertyRepository.DeleteUserEntryLoadProperty(id);
    }
}
