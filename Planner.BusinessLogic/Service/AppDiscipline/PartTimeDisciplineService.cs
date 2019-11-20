using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppDiscipline
{
    public class PartTimeDisciplineService : IPartTimeDisciplineService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PartTimeDisciplineService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PartTimeDisciplineDto>> GetPartTimeDisciplinesByDepartmentId(int id)
        {
            var partTimeDisciplines = await _uow.PartTimeDisciplineRepository.GetPartTimeDisciplinesByDepartmentId(id);

            return _mapper.Map<IEnumerable<PartTimeDisciplineDto>>(partTimeDisciplines);
        }

        public async Task<int> InsertPartTimeDiscipline(PartTimeDisciplineDto partTimeDisciplineDto)
        {
            var partTimeDiscipline = _mapper.Map<PartTimeDiscipline>(partTimeDisciplineDto);

            return await _uow.PartTimeDisciplineRepository.InsertPartTimeDiscipline(partTimeDiscipline);
        }
    }
}
