using Planner.Entities.Domain.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppSelectedDiscipline
{
    public interface IPracticalRepository
    {
        Task<int> InsertPractical(Practical practical);
    }
}