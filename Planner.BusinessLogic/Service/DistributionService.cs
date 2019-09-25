using AutoMapper;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.DTO.Distribution;
using Planner.ServiceInterfaces.Interfaces;
using System.Collections.Generic;

namespace Planner.BusinessLogic.Service
{
    public class DistributionService : IDistributionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;


        public DistributionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public IEnumerable<DayEntryDTO> GetDayEntry(int semester, int year)
        {
            var dayEntryLoad = _uow.DayEntryLoadRepository.GetBySemester(semester, year);

            return _mapper.Map<IEnumerable<DayEntryDTO>>(dayEntryLoad);

        }
    }
}
