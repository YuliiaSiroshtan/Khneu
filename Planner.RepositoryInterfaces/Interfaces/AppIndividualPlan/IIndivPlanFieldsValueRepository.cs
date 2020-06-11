using Planner.Entities.Domain;
using Planner.Entities.Domain.AppIndividualPlan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppIndividualPlan
{
    public interface IIndivPlanFieldsValueRepository
    {
        //void UpdateIndivPlanFieldValue(IndivPlanFieldsValue indivPlanFieldValue);

        Task<IEnumerable<IndivPlanFieldsValue>> GetIndivPlanFieldValue(string userName);
    }
}
