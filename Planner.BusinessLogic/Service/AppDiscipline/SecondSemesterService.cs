using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppDiscipline
{
    public class SecondSemesterService : BaseService, ISecondSemesterService
    {
        public SecondSemesterService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<int> InsertSecondSemester(SecondSemesterDto secondSemesterDto)
        {
            var secondSemester = this.Mapper.Map<SecondSemester>(secondSemesterDto);

            return await this.Uow.SecondSemesterRepository.InsertSecondSemester(secondSemester);
        }
    }
}