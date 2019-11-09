using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.DTO;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
{
    public class DisciplineService : IDisciplineService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DisciplineService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DisciplineDto>> GetDisciplines()
        {
            var disciplines = await _uow.DisciplineRepository.GetDisciplines();

            return _mapper.Map<IEnumerable<DisciplineDto>>(disciplines);
        }

        public async Task<IEnumerable<DisciplineDto>> GetDisciplinesByDepartmentId(int id)
        {
            var disciplines = await _uow.DisciplineRepository.GetDisciplinesByDepartmentId(id);

            return _mapper.Map<IEnumerable<DisciplineDto>>(disciplines);
        }

        public async Task DeleteDiscipline(int id)
        {
            await _uow.DisciplineRepository.DeleteDiscipline(id);
        }

        public async Task<DisciplineDto> GetDisciplineById(int id)
        {
            var discipline = await _uow.DisciplineRepository.GetDisciplineById(id);

            return _mapper.Map<DisciplineDto>(discipline);
        }

        public async Task<DisciplineDto> GetDisciplineByName(string name)
        {
            var discipline = await _uow.DisciplineRepository.GetDisciplineByName(name);

            return _mapper.Map<DisciplineDto>(discipline);
        }

        public async Task UpdateDiscipline(DisciplineDto disciplineDto)
        {
            var discipline = _mapper.Map<Discipline>(disciplineDto);

            await _uow.DisciplineRepository.UpdateDiscipline(discipline);
        }

        public async Task<int> InsertDiscipline(DisciplineDto disciplineDto)
        {
            var discipline = _mapper.Map<Discipline>(disciplineDto);

            return await _uow.DisciplineRepository.InsertDiscipline(discipline);
        }
    }
}
