using Planner.Entities.Domain;
using System.Collections.Generic;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IIndivPlanFieldsRepository
    {
        IEnumerable<IndivPlanFields> GetIndivPlanField(string indPlanTypeId);
    }
}
