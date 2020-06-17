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
    public class PlanTrainingJobRepository : GenericRepository<PlanTrainingJob>, IPlanTrainingRepository
    {
        public PlanTrainingJobRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

        public async Task<IEnumerable<PlanTrainingJob>> GetTrainingJob(string userName)
        {
            using var connection = await this.OpenConnection();

            string query = $"SELECT * FROM PlanTrainingJobs p, Users u WHERE p.ApplicationUserId = u.Id AND u.Login = '{userName}';";

            return await connection.QueryAsync<PlanTrainingJob>(query);
        }

        public async Task UpdateTrainingJob(PlanTrainingJob trainingJob)
        {
            await Update(trainingJob);
        }
    }
}
