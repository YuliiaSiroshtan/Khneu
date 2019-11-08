using System.Collections.Generic;
using System.Linq;
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
            //todo сделать репозиторий для вставки вібраніх дисциплин и для рейтов пользователя в отношения многие ко многим.
            await Update(user);
        }

        public async Task<int> InsertUser(User user) => await Insert(user);
    }
}
