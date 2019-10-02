using AutoMapper;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.UoW;
using Planner.ServiceInterfaces.DTO;
using Planner.ServiceInterfaces.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Service
{
    public class NdrService : INdrService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;

        public NdrService(IUnitOfWork uow, IMapper mapper, ISecurityService securityService)
        {
            _uow = uow;
            _mapper = mapper;
            _securityService = securityService;
        }

        public async Task<bool> AddNdr(NdrDTO ndrDTO)
        {
            var ndr = _mapper.Map<NDR>(ndrDTO);
            _uow.NdrRepository.AddNdr(ndr);

            return await _uow.SaveChanges() >= 0;
        }

        public IEnumerable<NdrListDTO> GetUserNdr(string userName)
        {
            var ndrs = _uow.NdrRepository.GetUserNdr(userName);

            return _mapper.Map<IEnumerable<NdrListDTO>>(ndrs);
        }
    }
}
