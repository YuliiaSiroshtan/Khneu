using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppDiscipline
{
    public class PartTimeDisciplineService : BaseService, IPartTimeDisciplineService
    {
        public PartTimeDisciplineService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope,
            mapper) { }

        public async Task<IEnumerable<PartTimeDisciplineDto>> GetPartTimeDisciplinesByDepartmentId(int id)
        {
            var partTimeDisciplines =
                await this.RepositoryScope.PartTimeDisciplineRepository.GetPartTimeDisciplinesByDepartmentId(id);

            return this.Mapper.Map<IEnumerable<PartTimeDisciplineDto>>(partTimeDisciplines);
        }

        public async Task<int> InsertPartTimeDiscipline(PartTimeDisciplineDto partTimeDisciplineDto)
        {
            var partTimeDiscipline = this.Mapper.Map<PartTimeDiscipline>(partTimeDisciplineDto);

            return await this.RepositoryScope.PartTimeDisciplineRepository.InsertPartTimeDiscipline(partTimeDiscipline);
        }
    }
}