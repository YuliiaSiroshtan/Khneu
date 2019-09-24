using AutoMapper;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.DTO.Distribution;
using Planner.ServiceInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.BusinessLogic.Service
{
    public class DistributionService: IDistributionService
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;


        public DistributionService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public IEnumerable<DayEntryDTO> GetDayEntry(Int32 semester, Int32 year)
        {
            IEnumerable<DayEntryLoad> dayEntryLoad = _uow.DayEntryLoadRepository.GetBySemester(semester, year);

            return _mapper.Map<IEnumerable<DayEntryDTO>>(dayEntryLoad);

        }
    }
}
