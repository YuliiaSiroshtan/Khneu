using AutoMapper;
using Planner.BusinessLogic.Service.Base;
using Planner.Entities.DTO.UniversityUnits;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppUniversityUnits
{
    public class FacultyService : BaseService, IFacultyService
    {
        public FacultyService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public async Task<IEnumerable<FacultyDto>> GetFaculties()
        {
            var faculties = await this.Uow.FacultyRepository.GetFaculties();

            return this.Mapper.Map<IEnumerable<FacultyDto>>(faculties);
        }

        public async Task<FacultyDto> GetFacultyById(int id)
        {
            var faculty = await this.Uow.FacultyRepository.GetFacultyById(id);

            return this.Mapper.Map<FacultyDto>(faculty);
        }

        public async Task<FacultyDto> GetFacultyByName(string name)
        {
            var faculty = await this.Uow.FacultyRepository.GetFacultyByName(name);

            return this.Mapper.Map<FacultyDto>(faculty);
        }
    }
}