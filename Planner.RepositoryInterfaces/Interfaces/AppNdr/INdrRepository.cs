using Planner.Entities.Domain;
using Planner.Entities.Domain.AppNdr;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppNdr
{
    public interface INdrRepository
    {
        Task<IEnumerable<NDR>> GetUserNdr(string userName);
        //Task<int> AddNdr(NDR ndr);
    }
}
