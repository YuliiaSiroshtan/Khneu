using Planner.Entities.Domain;
using System.Collections.Generic;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IIndividualPlanFieldsValueRepository
    {
        void UpdateIndividualPlanFieldValue(IndivPlanFieldsValue individualPlanFieldValue);
        IEnumerable<IndivPlanFieldsValue> GetIndividualPlanFieldValue(string userName);
    }
}
