using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service.AppDiscipline
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

        public async Task<int> InsertFirstSemester(FirstSemesterDto firstSemesterDto)
        {
            var firstSemester = _mapper.Map<FirstSemester>(firstSemesterDto);

            return await _uow.FirstSemesterRepository.InsertFirstSemester(firstSemester);
        }
    }
}
