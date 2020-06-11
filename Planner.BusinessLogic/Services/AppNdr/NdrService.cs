using AutoMapper;
using Planner.BusinessLogic.Services.Base;
using Planner.Entities.Domain;
using Planner.Entities.Domain.AppNdr;
using Planner.Entities.DTO.AppNdrDto;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using Planner.ServiceInterfaces.Interfaces;
using Planner.ServiceInterfaces.Interfaces.AppNdr;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BusinessLogic.Services.AppNdr
{
    public class NdrService : BaseService, INdrService
    {        
        public NdrService(IRepositoryScope repositoryScope, IMapper mapper) : base(repositoryScope, mapper) { }


        public async Task<IEnumerable<NdrListDTO>> GetUserNdr(string userName)
        {
            IEnumerable<NDR> ndrs = await RepositoryScope.NdrRepository.GetUserNdr(userName);
            return Mapper.Map<IEnumerable<NdrListDTO>>(ndrs);
        }

        public Task<int> AddNdr(NdrDTO ndrDTO)
        {
            var ndr = Mapper.Map<NDR>(ndrDTO);
            return RepositoryScope.NdrRepository.AddNdr(ndr);

            //return _uow.SaveChanges() >= 0;
        }
    }
}
