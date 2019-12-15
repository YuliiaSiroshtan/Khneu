using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.DTO.AppSelectedDisciplineDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppSelectedDiscipline
{
    public class SelectedDisciplineService : BaseService, ISelectedDisciplineService
    {
        public SelectedDisciplineService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope,
            mapper) { }

        public async Task<IEnumerable<SelectedDisciplineDto>> GetSelectedDisciplines()
        {
            var selectedDisciplines = await this.RepositoryScope.SelectedDisciplineRepository.GetSelectedDisciplines();

            return this.Mapper.Map<IEnumerable<SelectedDisciplineDto>>(selectedDisciplines);
        }

        public async Task DeleteSelectedDiscipline(int id) =>
            await this.RepositoryScope.SelectedDisciplineRepository.DeleteSelectedDiscipline(id);

        public async Task<SelectedDisciplineDto> GetSelectedDisciplineById(int id)
        {
            var selectedDiscipline =
                await this.RepositoryScope.SelectedDisciplineRepository.GetSelectedDisciplineById(id);

            return this.Mapper.Map<SelectedDisciplineDto>(selectedDiscipline);
        }

        public async Task<SelectedDisciplineDto> GetSelectedDisciplineByName(string name)
        {
            var selectedDiscipline =
                await this.RepositoryScope.SelectedDisciplineRepository.GetSelectedDisciplineByName(name);

            return this.Mapper.Map<SelectedDisciplineDto>(selectedDiscipline);
        }

        public async Task UpdateSelectedDiscipline(SelectedDisciplineDto selectedDisciplineDto)
        {
            var selectedDiscipline = this.Mapper.Map<SelectedDiscipline>(selectedDisciplineDto);

            await this.RepositoryScope.SelectedDisciplineRepository.UpdateSelectedDiscipline(selectedDiscipline);
        }

        public async Task<int> InsertSelectedDiscipline(SelectedDisciplineDto selectedDisciplineDto)
        {
            var selectedDiscipline = this.Mapper.Map<SelectedDiscipline>(selectedDisciplineDto);

            return await this.RepositoryScope.SelectedDisciplineRepository.InsertSelectedDiscipline(selectedDiscipline);
        }
    }
}