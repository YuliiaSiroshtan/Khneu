using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppUser;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppUser;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppUser
{
    public class RateRepository : GenericRepository<Rate>, IRateRepository
    {
        public RateRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task DeleteRate(int id) => await DeleteEntity(id);

        public async Task UpdateRate(Rate rate) => await Update(rate);

        public async Task<int> InsertRate(Rate rate) => await Insert(rate);
    }
}
