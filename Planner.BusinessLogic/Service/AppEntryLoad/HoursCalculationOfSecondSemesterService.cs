using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppEntryLoad
{
    public class HoursCalculationOfSecondSemesterService : IHoursCalculationOfSecondSemesterService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public HoursCalculationOfSecondSemesterService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<int> InsertHoursCalculationOfSecondSemester(HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemesterDto)
        {
            var hoursCalculationOfSecondSemester =
                _mapper.Map<HoursCalculationOfSecondSemester>(hoursCalculationOfSecondSemesterDto);

            return await _uow.HoursCalculationOfSecondSemesterRepository
                .InsertHoursCalculationOfSecondSemester(hoursCalculationOfSecondSemester);
        }
    }
}

