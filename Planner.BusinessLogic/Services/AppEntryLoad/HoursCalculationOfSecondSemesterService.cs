using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppEntryLoad
{
    public class HoursCalculationOfSecondSemesterService : BaseService, IHoursCalculationOfSecondSemesterService
    {
        public HoursCalculationOfSecondSemesterService(IRepositoryScope repositoryScope, IMapper mapper) : base(
            repositoryScope, mapper) { }

        public async Task<int> InsertHoursCalculationOfSecondSemester(
            HoursCalculationOfSecondSemesterDto hoursCalculationOfSecondSemesterDto)
        {
            var hoursCalculationOfSecondSemester =
                this.Mapper.Map<HoursCalculationOfSecondSemester>(hoursCalculationOfSecondSemesterDto);

            return await this.RepositoryScope.HoursCalculationOfSecondSemesterRepository
                .InsertHoursCalculationOfSecondSemester(hoursCalculationOfSecondSemester);
        }
    }
}