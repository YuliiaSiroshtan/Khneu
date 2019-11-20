using Dapper;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppUser;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppUser
{
    public class UserEntryLoadPropertyRepository : GenericRepository<UserEntryLoadProperty>, IUserEntryLoadPropertyRepository
    {
        public UserEntryLoadPropertyRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<UserEntryLoadProperty>> GetUserEntryLoadPropertiesByUserId(int id)
        {
            using var connection = await OpenConnection();

            const string query = "SELECT * FROM UserEntryLoadsProperties up " +
                                 "WHERE up.UserId = @id";

            return await connection.QueryAsync<UserEntryLoadProperty>(query);
        }

        public async Task<UserEntryLoadProperty> GetUserEntryLoadPropertyById(int id) => await GetEntityById(id);

        public async Task<int> InsertUserEntryLoadProperty(UserEntryLoadProperty userEntryLoadProperty) =>
            await Insert(userEntryLoadProperty);

        public async Task DeleteUserEntryLoadProperty(int id) => await DeleteEntity(id);
    }
}
