using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppDiscipline
{
    public class FirstSemesterService : BaseService, IFirstSemesterService
    {
        public FirstSemesterService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<int> InsertFirstSemester(FirstSemesterDto firstSemesterDto)
        {
            var firstSemester = this.Mapper.Map<FirstSemester>(firstSemesterDto);

            return await this.Uow.FirstSemesterRepository.InsertFirstSemester(firstSemester);
        }
    }
}