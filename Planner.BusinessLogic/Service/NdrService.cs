using AutoMapper;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.Interfaces;
using System.Collections.Generic;

namespace Planner.BusinessLogic.Service
{
    public class NdrService : INdrService
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private ISecurityService _securityService;

        public NdrService(IUnitOfWork uow, IMapper mapper, ISecurityService securityService)
        {
            _uow = uow;
            _mapper = mapper;
            _securityService = securityService;
        }

        public bool AddNdr(NdrDTO ndrDTO)
        {
            NDR ndr = _mapper.Map<NDR>(ndrDTO);
            _uow.NdrRepository.AddNdr(ndr);

            return _uow.SaveChanges() >= 0;
        }

        public IEnumerable<NdrListDTO> GetUserNdr(string userName)
        {
            IEnumerable<NDR> ndrs = _uow.NdrRepository.GetUserNdr(userName);
            return _mapper.Map<IEnumerable<NdrListDTO>>(ndrs);
        }
    }
}
