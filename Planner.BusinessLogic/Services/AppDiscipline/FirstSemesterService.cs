using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppDiscipline
{
    public class FirstSemesterService : BaseService, IFirstSemesterService
    {
        public FirstSemesterService(IRepositoryScope repositoryScope, IMapper mapper) :
            base(repositoryScope, mapper) { }

        public async Task<int> InsertFirstSemester(FirstSemesterDto firstSemesterDto)
        {
            var firstSemester = this.Mapper.Map<FirstSemester>(firstSemesterDto);

            return await this.RepositoryScope.FirstSemesterRepository.InsertFirstSemester(firstSemester);
        }
    }
}