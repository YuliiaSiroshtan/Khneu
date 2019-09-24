using Planner.Entities.Domain;
using System.Collections.Generic;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IIndivPlanFieldsValueRepository
    {
        void UpdateIndivPlanFieldValue(IndivPlanFieldsValue indivPlanFieldValue);
        IEnumerable<IndivPlanFieldsValue> GetIndivPlanFieldValue(string userName);
    }
}
