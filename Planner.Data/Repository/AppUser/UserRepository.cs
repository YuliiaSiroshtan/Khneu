using Dapper;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.Entities.Domain.AppUser;
using Planner.Entities.Domain.UniversityUnits;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppUser;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppUser
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

        public async Task<IEnumerable<User>> GetUsersByDepartmentId(int id)
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
                                 "WHERE d.Id = @id AND(d.Id = rt.DepartmentId AND d.Id = s.DepartmentId " +
                                 "OR rt.DepartmentId IS NULL OR s.DepartmentId IS NULL); ";

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
                user.Departments = groupingUser.Select(u => u.Departments.Single()).ToHashSet();
                user.Rates = groupingUser.Select(u => u.Rates.Single()).ToHashSet();
                user.SelectedDisciplines = groupingUser.Select(u => u.SelectedDisciplines.Single()).ToHashSet();

                return user;
            });
        }

        public async Task DeleteUser(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<User> GetUserById(int id)
        {
            using var connection = await OpenConnection();

            const string query = "SELECT * FROM Users u " +
                                 "JOIN Roles r ON r.Id = u.RoleId " +
                                 "FULL JOIN UserDepartment ud ON ud.UserId = u.Id " +
                                 "FULL JOIN Departments d ON d.Id = ud.DepartmentId " +
                                 "FULL JOIN Faculties f ON f.Id = d.FacultyId " +
                                 "FULL JOIN RateUser ru ON ru.UserId = u.Id " +
                                 "FULL JOIN Rates rt ON rt.Id = ru.RateId " +
                                 "FULL JOIN SelectedDisciplines sl ON sl.DepartmentId = d.Id OR sl.Id IS NULL " +
                                 "FULL JOIN Lectures lec ON lec.UserId = u.Id " +
                                 "FULL JOIN Laboratories lab ON lab.UserId = u.Id " +
                                 "FULL JOIN Practicals prac ON prac.UserId = u.Id " +
                                 "WHERE u.Id = @id AND(d.Id = rt.DepartmentId OR rt.DepartmentId IS NULL) " +
                                 "AND(lec.SelectedDisciplineId = sl.Id OR lec.Id IS NULL) " +
                                 "AND(lab.SelectedDisciplineId = sl.Id OR lab.Id IS NULL) " +
                                 "AND(prac.SelectedDisciplineId = sl.Id OR prac.Id IS NULL);";

            var users = await connection.QueryAsync(query, new[]
            {
                typeof(User),
                typeof(Role),
                typeof(Department),
                typeof(Faculty),
                typeof(Rate),
                typeof(SelectedDiscipline),
                typeof(Lecture),
                typeof(Laboratory),
                typeof(Practical)
            }, objects =>
            {
                if (!(objects[0] is User user))
                {
                    return null;
                }

                user.Role = objects[1] as Role;

                if (!(objects[2] is Department department))
                {
                    return user;
                }

                department.Faculty = objects[3] as Faculty;

                if (objects[4] is Rate rate)
                {
                    rate.Department = department;
                    user.Rates.Add(rate);
                }

                if (objects[5] is SelectedDiscipline selectedDiscipline)
                {
                    selectedDiscipline.Department = department;

                    if (objects[6] is Lecture lecture)
                    {
                        lecture.User = user;
                        lecture.SelectedDiscipline = selectedDiscipline;
                        selectedDiscipline.Lectures.Add(lecture);
                    }

                    if (objects[7] is Laboratory laboratory)
                    {
                        laboratory.User = user;
                        laboratory.SelectedDiscipline = selectedDiscipline;
                        selectedDiscipline.Laboratories.Add(laboratory);
                    }

                    if (objects[8] is Practical practical)
                    {
                        practical.User = user;
                        practical.SelectedDiscipline = selectedDiscipline;
                        selectedDiscipline.Practicals.Add(practical);
                    }

                    user.SelectedDisciplines.Add(selectedDiscipline);
                }

                user.Departments.Add(department);

                return user;
            }, new { Id = id }, splitOn: "RoleId, UserId, FacultyId, RateId, Id, Id, Id, Id");

            return users.GroupBy(u => u.Id).Select(groupingUser =>
            {
                var user = groupingUser.First();
                user.Departments = groupingUser.Select(u => u.Departments.Single()).ToHashSet();
                user.Rates = groupingUser.Select(u => u.Rates.Single()).ToHashSet();
                user.SelectedDisciplines = groupingUser.Select(u => u.SelectedDisciplines.Single()).ToHashSet();
                return user;
            }).SingleOrDefault();
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

        public async Task<string> GetUserNameById(int id)
        {
            using var connection = await OpenConnection();

            const string query = "SELECT u.Name FROM Users u " +
                                 "WHERE u.Id = @id;";

            return await connection.QuerySingleOrDefaultAsync<string>(query, new { Id = id });
        }

        public async Task UpdateUser(User user)
        {
            await Update(user);

            await DeleteUserSelectedDiscipline(user.Id);
            await DeleteUserDepartment(user.Id);
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

        public async Task<int> InsertUser(User user)
        {
            user.RoleId = 2; //default role user is "Викладач"
            if (user.Departments.Count > 0)
            {
                await InsertUserDepartment(user);
            }

            return await Insert(user);
        }

        #region private methods

        #region InsertEntity

        private async Task InsertUserSelectedDiscipline(User user)
        {
            using var connection = await OpenConnection();

            var query = new StringBuilder(
                "INSERT INTO UserSelectedDiscipline ([UserId], [SelectedDisciplineId]) VALUES ");

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