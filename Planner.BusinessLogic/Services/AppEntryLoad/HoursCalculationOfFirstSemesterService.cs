using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.DTO.AppEntryLoadDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppEntryLoad;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppEntryLoad
{
    public class HoursCalculationOfFirstSemesterService : BaseService, IHoursCalculationOfFirstSemesterService
    {
        public HoursCalculationOfFirstSemesterService(IRepositoryScope repositoryScope, IMapper mapper) : base(
            repositoryScope, mapper) { }

        public async Task<int> InsertHoursCalculationOfFirstSemester(
            HoursCalculationOfFirstSemesterDto hoursCalculationOfFirstSemesterDto)
        {
            var hoursCalculationOfFirstSemester =
                this.Mapper.Map<HoursCalculationOfFirstSemester>(hoursCalculationOfFirstSemesterDto);

            return await this.RepositoryScope.HoursCalculationOfFirstSemesterRepository
                .InsertHoursCalculationOfFirstSemester(hoursCalculationOfFirstSemester);
        }
    }
}