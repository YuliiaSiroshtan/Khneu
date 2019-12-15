using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.DTO.UniversityUnits;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppUniversityUnits
{
    public class FacultyService : BaseService, IFacultyService
    {
        public FacultyService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope, mapper) { }

        public async Task<IEnumerable<FacultyDto>> GetFaculties()
        {
            var faculties = await this.RepositoryScope.FacultyRepository.GetFaculties();

            return this.Mapper.Map<IEnumerable<FacultyDto>>(faculties);
        }

        public async Task<FacultyDto> GetFacultyById(int id)
        {
            var faculty = await this.RepositoryScope.FacultyRepository.GetFacultyById(id);

            return this.Mapper.Map<FacultyDto>(faculty);
        }

        public async Task<FacultyDto> GetFacultyByName(string name)
        {
            var faculty = await this.RepositoryScope.FacultyRepository.GetFacultyByName(name);

            return this.Mapper.Map<FacultyDto>(faculty);
        }
    }
}