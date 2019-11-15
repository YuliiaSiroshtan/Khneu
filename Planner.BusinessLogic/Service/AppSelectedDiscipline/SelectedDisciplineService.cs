using AutoMapper;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppSelectedDiscipline
{
    public class SelectedDisciplineService : ISelectedDisciplineService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SelectedDisciplineService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SelectedDisciplineDto>> GetSelectedDisciplines()
        {
            var selectedDisciplines = await _uow.SelectedDisciplineRepository.GetSelectedDisciplines();

            return _mapper.Map<IEnumerable<SelectedDisciplineDto>>(selectedDisciplines);
        }

        public async Task DeleteSelectedDiscipline(int id)
        {
            await _uow.SelectedDisciplineRepository.DeleteSelectedDiscipline(id);
        }

        public async Task<SelectedDisciplineDto> GetSelectedDisciplineById(int id)
        {
            var selectedDiscipline = await _uow.SelectedDisciplineRepository.GetSelectedDisciplineById(id);

            return _mapper.Map<SelectedDisciplineDto>(selectedDiscipline);
        }

        public async Task<SelectedDisciplineDto> GetSelectedDisciplineByName(string name)
        {
            var selectedDiscipline = await _uow.SelectedDisciplineRepository.GetSelectedDisciplineByName(name);

            return _mapper.Map<SelectedDisciplineDto>(selectedDiscipline);
        }

        public async Task UpdateSelectedDiscipline(SelectedDisciplineDto selectedDisciplineDto)
        {
            var selectedDiscipline = _mapper.Map<SelectedDiscipline>(selectedDisciplineDto);

            await _uow.SelectedDisciplineRepository.UpdateSelectedDiscipline(selectedDiscipline);
        }

        public async Task<int> InsertSelectedDiscipline(SelectedDisciplineDto selectedDisciplineDto)
        {
            var selectedDiscipline = _mapper.Map<SelectedDiscipline>(selectedDisciplineDto);

            return await _uow.SelectedDisciplineRepository.InsertSelectedDiscipline(selectedDiscipline);
        }
    }
}
