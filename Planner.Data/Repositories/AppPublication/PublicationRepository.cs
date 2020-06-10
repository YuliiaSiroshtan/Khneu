using Planner.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Planner.Data.Repositories.GenericRepository;
using Planner.Entities.Domain.AppPublication;
using System.Threading.Tasks;
using Dapper;
using Planner.RepositoryInterfaces.Interfaces.AppPublication;

namespace Planner.Data.Repositories.AppPublication
{
    public class PublicationRepository : GenericRepository<Publication>, IPublicationRepository
    {
        

        //public void AddUpdate(Publication publication)
        //{
        //    InsertOrUpdateGraph(publication);
        //}

        public PublicationRepository(string connectionString, string tableName) : base(connectionString, tableName) { }


        public async Task<IEnumerable<Publication>> GetAllPublications()
        {
            using var connection = await this.OpenConnection();

            const string query = "SELECT * FROM Publications p";

            return await connection.QueryAsync<Publication>(query);


            //return await Query.Include(s => s.PublicationUsers)
            //                    .ThenInclude(c => c.User).ToList();
        }

        public async Task<Publication> GetById(string publicationId)
        {
            using var connection = await this.OpenConnection();

            const string query =    "SELECT * FROM Publications p" +
                                    "WHERE p.PublicationId == @publicationId";

            return await connection.QueryFirstOrDefaultAsync<Publication>(query);
        }
    }
}
