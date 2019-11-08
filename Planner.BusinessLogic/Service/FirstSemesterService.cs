using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces;

namespace Planner.BusinessLogic.Service
{
    public class FirstSemesterService : IFirstSemesterService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public FirstSemesterService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FirstSemesterDto>> GetFirstSemesters()
        {
            var firstSemesters = await _uow.FirstSemesterRepository.GetFirstSemesters();

            return _mapper.Map<IEnumerable<FirstSemesterDto>>(firstSemesters);
        }

        public async Task DeleteFirstSemester(int id)
        {
            await _uow.FirstSemesterRepository.DeleteFirstSemester(id);
        }

        public async Task<FirstSemesterDto> GetFirstSemesterById(int id)
        {
            var firstSemester = await _uow.FirstSemesterRepository.GetFirstSemesterById(id);

            return _mapper.Map<FirstSemesterDto>(firstSemester);
        }

        public async Task UpdateFirstSemester(FirstSemesterDto firstSemesterDto)
        {
            var firstSemester = _mapper.Map<FirstSemester>(firstSemesterDto);

            await _uow.FirstSemesterRepository.UpdateFirstSemester(firstSemester);
        }

        public async Task<int> InsertFirstSemester(FirstSemesterDto firstSemesterDto)
        {
            var firstSemester = _mapper.Map<FirstSemester>(firstSemesterDto);

            return await _uow.FirstSemesterRepository.InsertFirstSemester(firstSemester);
        }
    }
}
