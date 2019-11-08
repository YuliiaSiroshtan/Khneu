using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Planner.RepositoryInterfaces.Repository;

namespace Planner.Data.GenericRepository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        protected GenericRepository(string connectionString, string tableName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
        }

        protected async Task<IDbConnection> OpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            return connection;
        }

        public async Task<IEnumerable<T>> GetEntities()
        {
            using var connection = await OpenConnection();

            return await connection
                .QueryAsync<T>($"SELECT * FROM {_tableName}");
        }

        public async Task DeleteEntity(int id)
        {
            using var connection = await OpenConnection();

            await connection.ExecuteAsync($"DELETE FROM {_tableName} " +
                                          $"WHERE Id = @Id", new { Id = id });
        }

        public async Task<T> GetEntityById(int id)
        {
            using var connection = await OpenConnection();

            return await connection
                .QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} " +
                                              $"WHERE Id = @Id", new { Id = id });
        }

        public async Task<T> GetEntityByName(string name)
        {
            using var connection = await OpenConnection();

            return await connection
                .QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} " +
                                              $"WHERE Name = @Name", new { Name = name });
        }

        public async Task Update(T entity)
        {
            using var connection = await OpenConnection();

            var updateQuery = GenerateUpdateQuery();
            await connection.ExecuteAsync(updateQuery, entity);
        }

        public async Task<int> Insert(T entity)
        {
            using var connection = await OpenConnection();

            var insertQuery = GenerateInsertQuery();

            return connection.QueryAsync<int>(insertQuery, entity).Result.SingleOrDefault();
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(Properties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1);
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }

        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(Properties);
            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    insertQuery.Append($"[{property}],");
                }
            });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    insertQuery.Append($"@{property},");
                }
            });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") SELECT CAST(SCOPE_IDENTITY() as int)");

            return insertQuery.ToString();
        }

        private static IEnumerable<PropertyInfo> Properties => typeof(T).GetProperties();

        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "Ignore"
                    select prop.Name).ToList();
        }

    }
}
