using Dapper;
using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppNdr;
using Planner.RepositoryInterfaces.Interfaces.AppNdr;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppNdr
{
    public class NdrRepository : GenericRepository<NDR>, INdrRepository
    {
        public NdrRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

        public async Task<IEnumerable<NDR>> GetUserNdr(string userName)
        {
            using var connection = await this.OpenConnection();

            string query =  $"SELECT * FROM Ndrs n, Users u WHERE n.ApplicationUserId = u.Id AND u.Login = '{userName}';";

            return await connection.QueryAsync<NDR>(query);
        }

        public async Task<int> AddNdr(NDR ndr) => await this.Insert(ndr);
    }
}
