using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.DTO.AppUserDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppUser
{
    public class RateService : BaseService, IRateService
    {
        public RateService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope, mapper) { }

        public async Task DeleteRate(int id) => await this.RepositoryScope.RateRepository.DeleteRate(id);

        public async Task UpdateRate(RateDto rateDto)
        {
            var rate = this.Mapper.Map<Rate>(rateDto);

            await this.RepositoryScope.RateRepository.UpdateRate(rate);
        }

        public async Task<int> InsertRate(RateDto rateDto)
        {
            var rate = this.Mapper.Map<Rate>(rateDto);

            return await this.RepositoryScope.RateRepository.InsertRate(rate);
        }
    }
}