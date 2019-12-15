using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppDiscipline
{
    public class SecondSemesterService : BaseService, ISecondSemesterService
    {
        public SecondSemesterService(IRepositoryScope repositoryScope, IMapper mapper) :
            base(repositoryScope, mapper) { }

        public async Task<int> InsertSecondSemester(SecondSemesterDto secondSemesterDto)
        {
            var secondSemester = this.Mapper.Map<SecondSemester>(secondSemesterDto);

            return await this.RepositoryScope.SecondSemesterRepository.InsertSecondSemester(secondSemester);
        }
    }
}