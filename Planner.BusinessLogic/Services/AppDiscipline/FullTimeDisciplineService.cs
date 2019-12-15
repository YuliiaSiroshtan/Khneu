using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppDiscipline
{
    public class FullTimeDisciplineService : BaseService, IFullTimeDisciplineService
    {
        public FullTimeDisciplineService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope,
            mapper) { }

        public async Task<IEnumerable<FullTimeDisciplineDto>> GetFullTimeDisciplinesByDepartmentId(int id)
        {
            var disciplines =
                await this.RepositoryScope.FullTimeDisciplineRepository.GetFullTimeDisciplinesByDepartmentId(id);

            return this.Mapper.Map<IEnumerable<FullTimeDisciplineDto>>(disciplines);
        }

        public async Task<int> InsertFullTimeDiscipline(FullTimeDisciplineDto fullTimeDisciplineDto)
        {
            var discipline = this.Mapper.Map<FullTimeDiscipline>(fullTimeDisciplineDto);

            return await this.RepositoryScope.FullTimeDisciplineRepository.InsertFullTimeDiscipline(discipline);
        }
    }
}