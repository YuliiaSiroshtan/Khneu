using Planner.Entities.Domain.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppSelectedDiscipline
{
    public interface IPracticalRepository
    {
        Task<int> InsertPractical(Practical practical);
    }
}