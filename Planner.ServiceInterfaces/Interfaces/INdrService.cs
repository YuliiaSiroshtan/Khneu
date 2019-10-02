using Planner.ServiceInterfaces.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface INdrService
    {
        Task<bool> AddNdr(NdrDTO userDTO);
        IEnumerable<NdrListDTO> GetUserNdr(string userName);
    }
}
