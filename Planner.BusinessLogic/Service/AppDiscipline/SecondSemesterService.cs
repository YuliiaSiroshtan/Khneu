using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppDiscipline
{
    public class SecondSemesterService : ISecondSemesterService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SecondSemesterService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SecondSemesterDto>> GetSecondSemesters()
        {
            var secondSemesters = await _uow.SecondSemesterRepository.GetSecondSemesters();

            return _mapper.Map<IEnumerable<SecondSemesterDto>>(secondSemesters);
        }

        public async Task DeleteSecondSemester(int id)
        {
            await _uow.SecondSemesterRepository.DeleteSecondSemester(id);
        }

        public async Task<SecondSemesterDto> GetSecondSemesterById(int id)
        {
            var secondSemester = await _uow.SecondSemesterRepository.GetSecondSemesterById(id);

            return _mapper.Map<SecondSemesterDto>(secondSemester);
        }

        public async Task UpdateSecondSemester(SecondSemesterDto secondSemesterDto)
        {
            var secondSemester = _mapper.Map<SecondSemester>(secondSemesterDto);

            await _uow.SecondSemesterRepository.UpdateSecondSemester(secondSemester);
        }

        public async Task<int> InsertSecondSemester(SecondSemesterDto secondSemesterDto)
        {
            var secondSemester = _mapper.Map<SecondSemester>(secondSemesterDto);

            return await _uow.SecondSemesterRepository.InsertSecondSemester(secondSemester);
        }
    }
}
