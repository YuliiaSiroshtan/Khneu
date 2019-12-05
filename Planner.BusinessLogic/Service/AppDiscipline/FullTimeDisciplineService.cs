using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppDiscipline
{
    public class FullTimeDisciplineService : BaseService, IFullTimeDisciplineService
    {
        public FullTimeDisciplineService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<IEnumerable<FullTimeDisciplineDto>> GetFullTimeDisciplinesByDepartmentId(int id)
        {
            var disciplines = await this.Uow.FullTimeDisciplineRepository.GetFullTimeDisciplinesByDepartmentId(id);

            return this.Mapper.Map<IEnumerable<FullTimeDisciplineDto>>(disciplines);
        }

        public async Task<int> InsertFullTimeDiscipline(FullTimeDisciplineDto fullTimeDisciplineDto)
        {
            var discipline = this.Mapper.Map<FullTimeDiscipline>(fullTimeDisciplineDto);

            return await this.Uow.FullTimeDisciplineRepository.InsertFullTimeDiscipline(discipline);
        }
    }
}