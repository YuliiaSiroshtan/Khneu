using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppEntryLoad
{
    public class HoursCalculationOfFirstSemesterService : BaseService, IHoursCalculationOfFirstSemesterService
    {
        public HoursCalculationOfFirstSemesterService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<int> InsertHoursCalculationOfFirstSemester(
            HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemesterDto)
        {
            var hoursCalculationOfFirstSemester =
                this.Mapper.Map<HoursCalculationOfFirstSemester>(hoursCalculationOfFirstSemesterDto);

            return await this.Uow.HoursCalculationOfFirstSemesterRepository
                .InsertHoursCalculationOfFirstSemester(hoursCalculationOfFirstSemester);
        }
    }
}