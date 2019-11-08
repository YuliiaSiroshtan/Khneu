using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
{
    public class FacultyService : IFacultyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FacultyService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FacultyDto>> GetFaculties()
        {
            var faculties = await _uow.FacultyRepository.GetFaculties();

            return _mapper.Map<IEnumerable<FacultyDto>>(faculties);
        }

        public async Task DeleteFaculty(int id)
        {
            await _uow.FacultyRepository.DeleteFaculty(id);
        }

        public async Task<FacultyDto> GetFacultyById(int id)
        {
            var faculty = await _uow.FacultyRepository.GetFacultyById(id);

            return _mapper.Map<FacultyDto>(faculty);
        }

        public async Task<FacultyDto> GetFacultyByName(string name)
        {
            var faculty = await _uow.FacultyRepository.GetFacultyByName(name);

            return _mapper.Map<FacultyDto>(faculty);
        }

        public async Task UpdateFaculty(FacultyDto facultyDto)
        {
            var faculty = _mapper.Map<Faculty>(facultyDto);

            await _uow.FacultyRepository.UpdateFaculty(faculty);
        }

        public async Task InsertFaculty(FacultyDto facultyDto)
        {
            var faculty = _mapper.Map<Faculty>(facultyDto);

            await _uow.FacultyRepository.InsertFaculty(faculty);
        }
    }
}
