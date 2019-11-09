using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.PartTime;
using Planner.Entities.DTO;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
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

        public async Task<IEnumerable<PartTimeDisciplineDto>> GetPartTimeDisciplines()
        {
            var partTimeDisciplines = await _uow.PartTimeDisciplineRepository.GetPartTimeDisciplines();

            return _mapper.Map<IEnumerable<PartTimeDisciplineDto>>(partTimeDisciplines);
        }

        public async Task<IEnumerable<PartTimeDisciplineDto>> GetPartTimeDisciplinesByDepartmentId(int id)
        {
            var partTimeDisciplines = await _uow.PartTimeDisciplineRepository.GetPartTimeDisciplinesByDepartmentId(id);

            return _mapper.Map<IEnumerable<PartTimeDisciplineDto>>(partTimeDisciplines);
        }

        public async Task DeletePartTimeDiscipline(int id)
        {
            await _uow.PartTimeDisciplineRepository.DeletePartTimeDiscipline(id);
        }

        public async Task<PartTimeDisciplineDto> GetPartTimeDisciplineById(int id)
        {
            var partTimeDiscipline = await _uow.PartTimeDisciplineRepository.GetPartTimeDisciplineById(id);

            return _mapper.Map<PartTimeDisciplineDto>(partTimeDiscipline);
        }

        public async Task<PartTimeDisciplineDto> GetPartTimeDisciplineByName(string name)
        {
            var partTimeDiscipline = await _uow.PartTimeDisciplineRepository.GetPartTimeDisciplineByName(name);

            return _mapper.Map<PartTimeDisciplineDto>(partTimeDiscipline);
        }

        public async Task UpdatePartTimeDiscipline(PartTimeDisciplineDto partTimeDisciplineDto)
        {
            var partTimeDiscipline = _mapper.Map<PartTimeDiscipline>(partTimeDisciplineDto);

            await _uow.PartTimeDisciplineRepository.UpdatePartTimeDiscipline(partTimeDiscipline);
        }

        public async Task<int> InsertPartTimeDiscipline(PartTimeDisciplineDto partTimeDisciplineDto)
        {
            var partTimeDiscipline = _mapper.Map<PartTimeDiscipline>(partTimeDisciplineDto);

            return await _uow.PartTimeDisciplineRepository.InsertPartTimeDiscipline(partTimeDiscipline);
        }
    }
}
