using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppDiscipline
{
    public class FullTimeDisciplineService : IFullTimeDisciplineService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FullTimeDisciplineService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FullTimeDisciplineDto>> GetFullTimeDisciplinesByDepartmentId(int id)
        {
            var disciplines = await _uow.FullTimeDisciplineRepository.GetFullTimeDisciplinesByDepartmentId(id);

            return _mapper.Map<IEnumerable<FullTimeDisciplineDto>>(disciplines);
        }

        public async Task<int> InsertFullTimeDiscipline(FullTimeDisciplineDto fullTimeDisciplineDto)
        {
            var discipline = _mapper.Map<FullTimeDiscipline>(fullTimeDisciplineDto);

            return await _uow.FullTimeDisciplineRepository.InsertFullTimeDiscipline(discipline);
        }
    }
}
