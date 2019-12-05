using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.DTO.AppUserDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppUser
{
    public class RateService : BaseService, IRateService
    {
        public RateService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task DeleteRate(int id) => await this.Uow.RateRepository.DeleteRate(id);

        public async Task UpdateRate(RateDto rateDto)
        {
            var rate = this.Mapper.Map<Rate>(rateDto);

            await this.Uow.RateRepository.UpdateRate(rate);
        }

        public async Task<int> InsertRate(RateDto rateDto)
        {
            var rate = this.Mapper.Map<Rate>(rateDto);

            return await this.Uow.RateRepository.InsertRate(rate);
        }
    }
}