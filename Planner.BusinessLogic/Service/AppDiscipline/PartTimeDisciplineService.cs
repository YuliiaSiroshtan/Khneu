using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppDiscipline
{
    public class PartTimeDisciplineService : BaseService, IPartTimeDisciplineService
    {
        public PartTimeDisciplineService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<IEnumerable<PartTimeDisciplineDto>> GetPartTimeDisciplinesByDepartmentId(int id)
        {
            var partTimeDisciplines =
                await this.Uow.PartTimeDisciplineRepository.GetPartTimeDisciplinesByDepartmentId(id);

            return this.Mapper.Map<IEnumerable<PartTimeDisciplineDto>>(partTimeDisciplines);
        }

        public async Task<int> InsertPartTimeDiscipline(PartTimeDisciplineDto partTimeDisciplineDto)
        {
            var partTimeDiscipline = this.Mapper.Map<PartTimeDiscipline>(partTimeDisciplineDto);

            return await this.Uow.PartTimeDisciplineRepository.InsertPartTimeDiscipline(partTimeDiscipline);
        }
    }
}