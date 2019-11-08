using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;
using Planner.Entities.Domain.AppUser;
using Planner.RepositoryInterfaces.ObjectInterfaces;

namespace Planner.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using var connection = await OpenConnection();

            const string query = "SELECT * FROM Users u " +
                                 "JOIN Roles r on r.Id = u.RoleId " +
                                 "JOIN UserDepartment ud on u.Id = ud.UserId " +
                                 "JOIN Departments d ON d.Id = ud.DepartmentId " +
                                 "JOIN Faculties f on f.Id = d.FacultyId " +
                                 "FULL JOIN RateUser ru on u.Id = ru.UserId " +
                                 "FULL JOIN Rates rt on rt.Id = ru.RateId " +
                                 "FULL JOIN UserSelectedDiscipline us on u.Id = us.UserId " +
                                 "FULL JOIN SelectedDisciplines s on s.Id = us.SelectedDisciplineId " +
                                 "WHERE d.Id = rt.DepartmentId AND d.Id = s.DepartmentId " +
                                 "OR rt.DepartmentId IS NULL OR s.DepartmentId IS NULL;";

            var users = await connection
                .QueryAsync<User, Role, Department, Faculty, Rate, SelectedDiscipline, User>
                (query, (user, role, department, faculty, rate, selectedDiscipline) =>
                {
                    user.Role = role;
                    department.Faculty = faculty;
                    selectedDiscipline.Department = department;
                    rate.Department = department;

                    user.Rates.Add(rate);
                    user.Departments.Add(department);
                    user.SelectedDisciplines.Add(selectedDiscipline);

                    return user;
                }, splitOn: "RoleId, UserId, FacultyId, RateId, SelectedDisciplineId");

            return users.GroupBy(u => u.Id).Select(groupingUser =>
            {
                var user = groupingUser.First();
                user.Departments = groupingUser.Select(u => u.Departments.Single()).ToHashSet();
                user.Rates = groupingUser.Select(u => u.Rates.Single()).ToHashSet();
                user.SelectedDisciplines = groupingUser.Select(u => u.SelectedDisciplines.Single()).ToHashSet();

                return user;
            });
        }

        public async Task DeleteUser(int id) => await DeleteEntity(id);

        public async Task<User> GetUserById(int id)
        {
            using var connection = await OpenConnection();

            const string query = "SELECT * FROM Users u " +
                                 "JOIN Roles r on r.Id = u.RoleId " +
                                 "JOIN UserDepartment ud on u.Id = ud.UserId " +
                                 "JOIN Departments d ON d.Id = ud.DepartmentId " +
                                 "JOIN Faculties f on f.Id = d.FacultyId " +
                                 "FULL JOIN RateUser ru on u.Id = ru.UserId " +
                                 "FULL JOIN Rates rt on rt.Id = ru.RateId " +
                                 "FULL JOIN UserSelectedDiscipline us on u.Id = us.UserId " +
                                 "FULL JOIN SelectedDisciplines s on s.Id = us.SelectedDisciplineId " +
                                 "WHERE u.Id = @id AND(d.Id = rt.DepartmentId AND d.Id = s.DepartmentId " +
                                 "OR rt.DepartmentId IS NULL OR s.DepartmentId IS NULL);";

            var users = await connection
                .QueryAsync<User, Role, Department, Faculty, Rate, SelectedDiscipline, User>
                (query, (user, role, department, faculty, rate, selectedDiscipline) =>
                  {
                      user.Role = role;
                      department.Faculty = faculty;
                      selectedDiscipline.Department = department;
                      rate.Department = department;

                      user.Rates.Add(rate);
                      user.Departments.Add(department);
                      user.SelectedDisciplines.Add(selectedDiscipline);

                      return user;
                  }, new { Id = id }, splitOn: "RoleId, UserId, FacultyId, RateId, SelectedDisciplineId");

            return users.GroupBy(u => u.Id).Select(groupingUser =>
            {
                var user = groupingUser.First();
                user.Departments = groupingUser.Select(u => u.Departments.Single()).Distinct().ToHashSet();
                user.Rates = groupingUser.Select(u => u.Rates.Single()).ToHashSet();
                user.SelectedDisciplines = groupingUser.Select(u => u.SelectedDisciplines.Single()).ToHashSet();

                return user;
            }).SingleOrDefault();
        }

        private static void Temp()
        {
            return;
        }
        public async Task<User> GetUserByLogin(string login)
        {
            using var connection = await OpenConnection();

            const string query = "SELECT * FROM Users u " +
                                 "JOIN Roles r on r.Id = u.RoleId " +
                                 "JOIN UserDepartment ud on u.Id = ud.UserId " +
                                 "JOIN Departments d ON d.Id = ud.DepartmentId " +
                                 "JOIN Faculties f on f.Id = d.FacultyId " +
                                 "FULL JOIN RateUser ru on u.Id = ru.UserId " +
                                 "FULL JOIN Rates rt on rt.Id = ru.RateId " +
                                 "FULL JOIN UserSelectedDiscipline us on u.Id = us.UserId " +
                                 "FULL JOIN SelectedDisciplines s on s.Id = us.SelectedDisciplineId " +
                                 "WHERE u.Login = @login AND(d.Id = rt.DepartmentId AND d.Id = s.DepartmentId " +
                                 "OR rt.DepartmentId IS NULL OR s.DepartmentId IS NULL);";

            var users = await connection
                .QueryAsync<User, Role, Department, Faculty, Rate, SelectedDiscipline, User>
                (query, (user, role, department, faculty, rate, selectedDiscipline) =>
                {
                    user.Role = role;
                    department.Faculty = faculty;
                    selectedDiscipline.Department = department;
                    rate.Department = department;

                    user.Rates.Add(rate);
                    user.Departments.Add(department);
                    user.SelectedDisciplines.Add(selectedDiscipline);

                    return user;
                }, new { Login = login }, splitOn: "RoleId, UserId, FacultyId, RateId, SelectedDisciplineId");

            return users.GroupBy(u => u.Id).Select(groupingUser =>
            {
                var user = groupingUser.First();
                user.Departments = groupingUser.Select(u => u.Departments.Single()).ToHashSet();
                user.Rates = groupingUser.Select(u => u.Rates.Single()).ToHashSet();
                user.SelectedDisciplines = groupingUser.Select(u => u.SelectedDisciplines.Single()).ToHashSet();

                return user;
            }).SingleOrDefault();
        }

        public async Task<User> GetUserByLoginAndPassword(string login, string password)
        {
            using var connection = await OpenConnection();

            const string query = "SELECT * FROM Users u " +
                                 "LEFT JOIN Roles r on r.Id = u.RoleId " +
                                 "WHERE Login = @Login AND Password = @Password;";

            var users = await connection
                .QueryAsync<User, Role, User>(query, (user, role) =>
               {
                   user.Role = role;

                   return user;
               }, new { Login = login, Password = password }, splitOn: "RoleId");

            return users.SingleOrDefault();
        }

        public async Task UpdateUser(User user)
        {
            await Update(user);

            await DeleteUserDepartment(user.Id);
            await DeleteUserSelectedDiscipline(user.Id);
            await DeleteRateUser(user.Id);

            if (user.Departments.Count > 0)
            {
                await InsertUserDepartment(user);
            }

            if (user.SelectedDisciplines.Count > 0)
            {
                await InsertUserSelectedDiscipline(user);
            }

            if (user.Rates.Count > 0)
            {
                await InsertRateUser(user);
            }
        }

        public async Task<int> InsertUser(User user) => await Insert(user);

        #region private methods

        #region InsertEntity

        private async Task InsertUserSelectedDiscipline(User user)
        {
            using var connection = await OpenConnection();

            var query = new StringBuilder("INSERT INTO CategoryGame ([UserId], [SelectedDisciplineId]) VALUES ");

            foreach (var selectedDiscipline in user.SelectedDisciplines)
            {
                query.Append("(").Append(user.Id).Append(",").Append(selectedDiscipline.Id).Append(")").Append(",");
            }

            query.Remove(query.Length - 1, 1);

            await connection.ExecuteAsync(query.ToString());
        }

        private async Task InsertUserDepartment(User user)
        {
            using var connection = await OpenConnection();

            var query = new StringBuilder("INSERT INTO UserDepartment ([UserId], [DepartmentId]) VALUES ");

            foreach (var department in user.Departments)
            {
                query.Append("(").Append(user.Id).Append(",").Append(department.Id).Append(")").Append(",");
            }

            query.Remove(query.Length - 1, 1);

            await connection.ExecuteAsync(query.ToString());
        }

        private async Task InsertRateUser(User user)
        {
            using var connection = await OpenConnection();

            var query = new StringBuilder("INSERT INTO RateUser ([RateId], [UserId]) VALUES ");

            foreach (var rate in user.Rates)
            {
                query.Append("(").Append(rate.Id).Append(",").Append(user.Id).Append(")").Append(",");
            }

            query.Remove(query.Length - 1, 1);

            await connection.ExecuteAsync(query.ToString());
        }

        #endregion

        #region DeleteEntity

        private async Task DeleteUserSelectedDiscipline(int id)
        {
            using var connection = await OpenConnection();

            const string query = "DELETE FROM UserSelectedDiscipline " +
                                 "WHERE UserId = @UserId";

            await connection.ExecuteAsync(query, new { UserId = id });
        }

        private async Task DeleteUserDepartment(int id)
        {
            using var connection = await OpenConnection();

            const string query = "DELETE FROM UserDepartment " +
                                 "WHERE UserId = @UserId";

            await connection.ExecuteAsync(query, new { UserId = id });
        }

        private async Task DeleteRateUser(int id)
        {
            using var connection = await OpenConnection();

            const string query = "DELETE FROM RateUser " +
                                 "WHERE UserId = @UserId";

            await connection.ExecuteAsync(query, new { UserId = id });
        }

        #endregion

        #endregion

    }
}
