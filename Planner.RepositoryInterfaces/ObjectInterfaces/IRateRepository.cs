using System.Threading.Tasks;
using Planner.Entities.Domain.AppUser;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IRateRepository
    {
        Task DeleteRate(int id);

        Task UpdateRate(Rate rate);

        Task<int> InsertRate(Rate rate);
    }
}
