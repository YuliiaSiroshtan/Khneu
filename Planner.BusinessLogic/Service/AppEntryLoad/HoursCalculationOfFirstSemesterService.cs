using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppEntryLoad
{
    public class HoursCalculationOfFirstSemesterService : IHoursCalculationOfFirstSemesterService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public HoursCalculationOfFirstSemesterService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<int> InsertHoursCalculationOfFirstSemester(HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemesterDto)
        {
            var hoursCalculationOfFirstSemester =
                _mapper.Map<HoursCalculationOfFirstSemester>(hoursCalculationOfFirstSemesterDto);

            return await _uow.HoursCalculationOfFirstSemesterRepository
                .InsertHoursCalculationOfFirstSemester(hoursCalculationOfFirstSemester);
        }
    }
}
