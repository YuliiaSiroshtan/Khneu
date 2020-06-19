using Planner.Entities.DTO.AppNdrDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppNdr
{
    public interface INdrService
    {
        Task<IEnumerable<NdrListDTO>> GetUserNdr(string userName);
        Task<int> AddNdr(NdrDTO userDTO);
    }
}
