using AutoMapper;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.DTO.AppUserDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppUser;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppUser
{
    public class RateService : IRateService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RateService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task DeleteRate(int id)
        {
            await _uow.RateRepository.DeleteRate(id);
        }

        public async Task UpdateRate(RateDto rateDto)
        {
            var rate = _mapper.Map<Rate>(rateDto);

            await _uow.RateRepository.UpdateRate(rate);
        }

        public async Task<int> InsertRate(RateDto rateDto)
        {
            var rate = _mapper.Map<Rate>(rateDto);

            return await _uow.RateRepository.InsertRate(rate);
        }
    }
}
