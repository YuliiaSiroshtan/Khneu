using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppSelectedDiscipline
{
    public class SelectedDisciplineService : BaseService, ISelectedDisciplineService
    {
        public SelectedDisciplineService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<IEnumerable<SelectedDisciplineDto>> GetSelectedDisciplines()
        {
            var selectedDisciplines = await this.Uow.SelectedDisciplineRepository.GetSelectedDisciplines();

            return this.Mapper.Map<IEnumerable<SelectedDisciplineDto>>(selectedDisciplines);
        }

        public async Task DeleteSelectedDiscipline(int id) =>
            await this.Uow.SelectedDisciplineRepository.DeleteSelectedDiscipline(id);

        public async Task<SelectedDisciplineDto> GetSelectedDisciplineById(int id)
        {
            var selectedDiscipline = await this.Uow.SelectedDisciplineRepository.GetSelectedDisciplineById(id);

            return this.Mapper.Map<SelectedDisciplineDto>(selectedDiscipline);
        }

        public async Task<SelectedDisciplineDto> GetSelectedDisciplineByName(string name)
        {
            var selectedDiscipline = await this.Uow.SelectedDisciplineRepository.GetSelectedDisciplineByName(name);

            return this.Mapper.Map<SelectedDisciplineDto>(selectedDiscipline);
        }

        public async Task UpdateSelectedDiscipline(SelectedDisciplineDto selectedDisciplineDto)
        {
            var selectedDiscipline = this.Mapper.Map<SelectedDiscipline>(selectedDisciplineDto);

            await this.Uow.SelectedDisciplineRepository.UpdateSelectedDiscipline(selectedDiscipline);
        }

        public async Task<int> InsertSelectedDiscipline(SelectedDisciplineDto selectedDisciplineDto)
        {
            var selectedDiscipline = this.Mapper.Map<SelectedDiscipline>(selectedDisciplineDto);

            return await this.Uow.SelectedDisciplineRepository.InsertSelectedDiscipline(selectedDiscipline);
        }
    }
}