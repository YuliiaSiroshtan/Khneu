using Dapper;
using Microsoft.Data.SqlClient;
using Planner.Entities.Domain.Base;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.GenericRepository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        protected GenericRepository(string connectionString, string tableName)
        {
            this._connectionString = connectionString;
            this._tableName = tableName;
        }

        private static IEnumerable<PropertyInfo> Properties => typeof(T).GetProperties();

        public async Task<IEnumerable<T>> GetEntities()
        {
            using var connection = await this.OpenConnection();

            return await connection
                .QueryAsync<T>($"SELECT * FROM {this._tableName}");
        }

        public async Task DeleteEntity(int id)
        {
            using var connection = await this.OpenConnection();

            await connection.ExecuteAsync($"DELETE FROM {this._tableName} " +
                                          "WHERE Id = @Id", new { Id = id });
        }

        public async Task<T> GetEntityById(int id)
        {
            using var connection = await this.OpenConnection();

            return await connection
                .QuerySingleOrDefaultAsync<T>($"SELECT * FROM {this._tableName} " +
                                              "WHERE Id = @Id", new { Id = id });
        }

        public async Task<T> GetEntityByName(string name)
        {
            using var connection = await this.OpenConnection();

            return await connection
                .QuerySingleOrDefaultAsync<T>($"SELECT * FROM {this._tableName} " +
                                              "WHERE Name = @Name", new { Name = name });
        }

        public async Task Update(T entity)
        {
            using var connection = await this.OpenConnection();

            var updateQuery = this.GenerateUpdateQuery();
            await connection.ExecuteAsync(updateQuery, entity);
        }

        public async Task<int> Insert(T entity)
        {
            using var connection = await this.OpenConnection();

            var insertQuery = this.GenerateInsertQuery();

            return connection.QueryAsync<int>(insertQuery, entity).Result.SingleOrDefault();
        }

        protected async Task<IDbConnection> OpenConnection()
        {
            var connection = new SqlConnection(this._connectionString);
            await connection.OpenAsync();

            return connection;
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {this._tableName} SET ");
            var properties = GenerateListOfProperties(Properties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id") && !property.Equals("Password"))
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
            var insertQuery = new StringBuilder($"SET IDENTITY_INSERT {this._tableName} ON INSERT INTO {this._tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(Properties);
            properties.ForEach(property =>
            {
                if (!property.Equals("Id")) insertQuery.Append($"[{property}],");
            });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(property =>
            {
                if (!property.Equals("Id")) insertQuery.Append($"@{property},");
            });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") SELECT CAST(SCOPE_IDENTITY() as int)");

            return insertQuery.ToString();
        }

        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties) =>
            (from prop in listOfProperties
             let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
             where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "Ignore"
             select prop.Name).ToList();
    }
}