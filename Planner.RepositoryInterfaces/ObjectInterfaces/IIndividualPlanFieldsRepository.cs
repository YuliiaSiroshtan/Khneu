using Planner.Entities.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IIndividualPlanFieldsRepository
    {
        Task<IEnumerable<IndivPlanFields>> GetIndivPlanField(string indPlanTypeId);
    }
}
