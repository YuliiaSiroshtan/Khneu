using AutoMapper;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.DTO.AppEntryLoadDto.FullTime;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.Interfaces.AppDiscipline;
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

        public async Task<int> InsertSecondSemester(SecondSemesterDto secondSemesterDto)
        {
            var secondSemester = _mapper.Map<SecondSemester>(secondSemesterDto);

            return await _uow.SecondSemesterRepository.InsertSecondSemester(secondSemester);
        }
    }
}
