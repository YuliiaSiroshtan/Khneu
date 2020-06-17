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
        public PublicationRepository(string connectionString, string tableName) : base(connectionString, tableName) { }


        public async Task<IEnumerable<Publication>> GetAllPublications(string userLogin)
        {
            using var connection = await this.OpenConnection();

            string query =  "SELECT p.Id, p.Name, p.FilePath, p.Pages, p.Output, p.CreatedAt, p.PublishedAt, " +
                                    "p.IsPublished, p.IsOverseas, p.OwnerId, p.CitationNumberNMBD, p.ImpactFactorNMBD, p.NMBDId " +
                                    "FROM Publications p, PublicationUsers pu, Users u " + 
                                    "WHERE p.Id = pu.PublicationId " +
                                    "AND pu.ApplicationUserId = u.Id " +
                                    $"AND u.Login = '{userLogin}'";

            return await connection.QueryAsync<Publication>(query);
        }

        public async Task<Publication> GetById(string publicationId)
        {
            using var connection = await this.OpenConnection();

            const string query =    "SELECT * FROM Publications p" +
                                    "WHERE p.Id == @publicationId";

            return await connection.QueryFirstOrDefaultAsync<Publication>(query);
        }

        public async Task UpdatePublication(Publication publication)
        {
            await Update(publication);
        }
    }
}
