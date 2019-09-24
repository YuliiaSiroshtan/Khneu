using Planner.Entities.Domain;
using System.Collections.Generic;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface INdrRepository
    {
        IEnumerable<NDR> GetUserNdr(string userName);

        void AddNdr(NDR ndr);
    }
}
