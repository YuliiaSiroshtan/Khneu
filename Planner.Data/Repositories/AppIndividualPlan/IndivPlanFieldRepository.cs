using Dapper;
using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain;
using Planner.Entities.Domain.AppIndividualPlan;
using Planner.RepositoryInterfaces.Interfaces.AppIndividualPlan;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.AppIndividualPlan
{
    public class IndivPlanFieldRepository : GenericRepository<IndivPlanFields>, IIndivPlanFieldsRepository
    {
        public IndivPlanFieldRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

        public async Task<IEnumerable<IndivPlanFields>> GetIndivPlanField(string indPlanTypeId)
        {
            using var connection = await this.OpenConnection();

            string query = $"SELECT * FROM IndivPlanFields ip WHERE ip.IndPlanTypeId = '{indPlanTypeId}';";

            return await connection.QueryAsync<IndivPlanFields>(query);
        }
    }
}
