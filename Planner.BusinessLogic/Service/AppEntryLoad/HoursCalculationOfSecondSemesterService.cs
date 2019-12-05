using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppEntryLoad
{
    public class HoursCalculationOfSecondSemesterService : BaseService, IHoursCalculationOfSecondSemesterService
    {
        public HoursCalculationOfSecondSemesterService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<int> InsertHoursCalculationOfSecondSemester(
            HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemesterDto)
        {
            var hoursCalculationOfSecondSemester =
                this.Mapper.Map<HoursCalculationOfSecondSemester>(hoursCalculationOfSecondSemesterDto);

            return await this.Uow.HoursCalculationOfSecondSemesterRepository
                .InsertHoursCalculationOfSecondSemester(hoursCalculationOfSecondSemester);
        }
    }
}