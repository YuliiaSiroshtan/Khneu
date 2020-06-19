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
    public class IndivPlanFieldsValueRepository : GenericRepository<IndivPlanFieldsValue>, IIndivPlanFieldsValueRepository
    {
        public IndivPlanFieldsValueRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

        public async Task<IEnumerable<IndivPlanFieldsValue>> GetIndivPlanFieldValue(string userName)
        {
            using var connection = await this.OpenConnection();

            string query = $"SELECT * FROM IndivPlanFieldsValues i, Users u WHERE i.ApplicationUserId = u.Id AND u.Login = '{userName}';";

            return await connection.QueryAsync<IndivPlanFieldsValue>(query);
        }

        public async Task UpdateIndivPlanFieldValue(IndivPlanFieldsValue indivPlanFieldValue)
        {
            await Update(indivPlanFieldValue);
        }
    }
}
