using System.Linq;
using Planner.RepositoryInterfaces.Interfaces.AppPublication;
using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppPublication;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;

namespace Planner.Data.Repositories.AppPublication
{
    public class NMBDRepository : GenericRepository<NMBD>, INMBDRepository
    {        
        //public NMBD GetById(String id)
        //{
        //    return Query.FirstOrDefault(s=> s.NMBDId == id);
        //}
        public NMBDRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

        public async Task<IEnumerable<NMBD>> GetAllNMBD()
        {
            using var connection = await this.OpenConnection();

            const string query = "SELECT * FROM NMBDs n";

            return await connection.QueryAsync<NMBD>(query);
        }
    }
}
