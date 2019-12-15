using Planner.Entities.Domain.AppUser;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppUser
{
    public interface IRateRepository
    {
        Task DeleteRate(int id);

        Task UpdateRate(Rate rate);

        Task<int> InsertRate(Rate rate);
    }
}