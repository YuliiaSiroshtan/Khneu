using Planner.ServiceInterfaces.DTO;
using System.Collections.Generic;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface INdrService
    {
        bool AddNdr(NdrDTO userDTO);
        IEnumerable<NdrListDTO> GetUserNdr(string userName);
    }
}
