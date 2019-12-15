using Dapper;
using Microsoft.Data.SqlClient;
using Planner.RepositoryInterfaces.Interfaces.Misc;
using System.Data;
using System.Threading.Tasks;

namespace Planner.Data.Repositories.Misc
{
    public class RecreateTables : IRecreateTables
    {
        private readonly string _connectionString;

        public RecreateTables(string connectionString) => this._connectionString = connectionString;

        public async Task Recreate()
        {
            var connection = await this.OpenConnection();

            const string dropConstantQuery =
                "ALTER TABLE [dbo].[FullTimeEntryLoads] " +
                "DROP CONSTRAINT [FK_FullTimeEntryLoads_FullTimeDisciplines_FullTimeDisciplineId];" +
                "ALTER TABLE[dbo].[FullTimeEntryLoads] " +
                "DROP CONSTRAINT[FK_FullTimeEntryLoads_Faculties_FacultyId];" +
                "ALTER TABLE [dbo].[FullTimeEntryLoads] " +
                "DROP CONSTRAINT [FK_FullTimeEntryLoads_HoursCalculationOfFirstSemesters_HoursCalculationOfFirstSemesterId];" +
                "ALTER TABLE [dbo].[FullTimeEntryLoads] " +
                "DROP CONSTRAINT [FK_FullTimeEntryLoads_HoursCalculationOfSecondSemesters_HoursCalculationOfSecondSemesterId];" +
                "ALTER TABLE [dbo].[FullTimeDisciplines] " +
                "DROP CONSTRAINT FK_FullTimeDisciplines_Departments_DepartmentId;" +
                "ALTER TABLE[dbo].[FullTimeDisciplines] " +
                "DROP CONSTRAINT FK_FullTimeDisciplines_FirstSemesters_FirstSemesterId;" +
                "ALTER TABLE[dbo].[FullTimeDisciplines] " +
                "DROP CONSTRAINT FK_FullTimeDisciplines_SecondSemesters_SecondSemesterId;" +
                "ALTER TABLE [dbo].[PartTimeEntryLoads] " +
                "DROP CONSTRAINT [FK_PartTimeEntryLoads_PartTimeDisciplines_PartTimeDisciplineId];" +
                "ALTER TABLE [dbo].[PartTimeDisciplines] " +
                "DROP CONSTRAINT [FK_PartTimeDisciplines_ConstituentSessions_ConstituentSessionId];" +
                "ALTER TABLE [dbo].[PartTimeEntryLoads] " +
                "DROP CONSTRAINT [FK_PartTimeEntryLoads_HoursCalculationOfFirstSemesters_HoursCalculationOfFirstSemesterId];" +
                "ALTER TABLE [dbo].[PartTimeEntryLoads] " +
                "DROP CONSTRAINT [FK_PartTimeEntryLoads_HoursCalculationOfSecondSemesters_HoursCalculationOfSecondSemesterId];" +
                "ALTER TABLE [dbo].[PartTimeDisciplines] " +
                "DROP CONSTRAINT [FK_PartTimeDisciplines_Departments_DepartmentId];" +
                "ALTER TABLE [dbo].[PartTimeDisciplines] " +
                "DROP CONSTRAINT [FK_PartTimeDisciplines_ExaminationSessions_ExaminationSessionId];";


            const string truncateQuery = "TRUNCATE TABLE [dbo].[FullTimeEntryLoads];" +
                                         "TRUNCATE TABLE [dbo].[FirstSemesters];" +
                                         "TRUNCATE TABLE [dbo].[SecondSemesters];" +
                                         "TRUNCATE TABLE [dbo].[FullTimeDisciplines];" +
                                         "TRUNCATE TABLE [dbo].[PartTimeDisciplines];" +
                                         "TRUNCATE TABLE [dbo].[PartTimeEntryLoads];" +
                                         "TRUNCATE TABLE [dbo].[ConstituentSessions];" +
                                         "TRUNCATE TABLE [dbo].[ExaminationSessions];" +
                                         "TRUNCATE TABLE [dbo].[HoursCalculationOfFirstSemesters];" +
                                         "TRUNCATE TABLE [dbo].[HoursCalculationOfSecondSemesters];";

            const string addConstantQuery = "ALTER TABLE [dbo].[FullTimeDisciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT [FK_FullTimeDisciplines_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] " +
                                            "ALTER TABLE [dbo].[FullTimeEntryLoads] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_FullTimeEntryLoads_HoursCalculationOfFirstSemesters_HoursCalculationOfFirstSemesterId] FOREIGN KEY([HoursCalculationOfFirstSemesterId]) REFERENCES[dbo].[HoursCalculationOfFirstSemesters]([Id]); " +
                                            "ALTER TABLE [dbo].[FullTimeEntryLoads] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_FullTimeEntryLoads_HoursCalculationOfSecondSemesters_HoursCalculationOfSecondSemesterId] FOREIGN KEY([HoursCalculationOfSecondSemesterId]) REFERENCES[dbo].[HoursCalculationOfSecondSemesters]([Id]); " +
                                            "ALTER TABLE [dbo].[FullTimeDisciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_FullTimeDisciplines_FirstSemesters_FirstSemesterId] FOREIGN KEY([FirstSemesterId]) REFERENCES[dbo].[FirstSemesters]([Id]);" +
                                            "ALTER TABLE [dbo].[FullTimeDisciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_FullTimeDisciplines_SecondSemesters_SecondSemesterId] FOREIGN KEY([SecondSemesterId]) REFERENCES[dbo].[SecondSemesters]([Id]);" +
                                            "ALTER TABLE [dbo].[FullTimeEntryLoads] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_FullTimeEntryLoads_FullTimeDisciplines_FullTimeDisciplineId] FOREIGN KEY([FullTimeDisciplineId]) REFERENCES[dbo].[FullTimeDisciplines]([Id]);" +
                                            "ALTER TABLE [dbo].[FullTimeEntryLoads] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_FullTimeEntryLoads_Faculties_FacultyId] FOREIGN KEY([FacultyId]) REFERENCES[dbo].[Faculties]([Id]);" +
                                            "ALTER TABLE [dbo].[PartTimeDisciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_PartTimeDisciplines_ConstituentSessions_ConstituentSessionId] FOREIGN KEY([ConstituentSessionId]) REFERENCES[dbo].[ConstituentSessions]([Id]);" +
                                            "ALTER TABLE [dbo].[PartTimeDisciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_PartTimeDisciplines_Departments_DepartmentId] FOREIGN KEY([DepartmentId]) REFERENCES[dbo].[Departments]([Id]); " +
                                            "ALTER TABLE [dbo].[PartTimeEntryLoads] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_PartTimeEntryLoads_HoursCalculationOfFirstSemesters_HoursCalculationOfFirstSemesterId] FOREIGN KEY([HoursCalculationOfFirstSemesterId]) REFERENCES[dbo].[HoursCalculationOfFirstSemesters]([Id]); " +
                                            "ALTER TABLE [dbo].[PartTimeEntryLoads] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_PartTimeEntryLoads_HoursCalculationOfSecondSemesters_HoursCalculationOfSecondSemesterId] FOREIGN KEY([HoursCalculationOfSecondSemesterId]) REFERENCES[dbo].[HoursCalculationOfSecondSemesters]([Id]); " +
                                            "ALTER TABLE [dbo].[PartTimeDisciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_PartTimeDisciplines_ExaminationSessions_ExaminationSessionId] FOREIGN KEY([ExaminationSessionId]) REFERENCES[dbo].[ExaminationSessions]([Id]); " +
                                            "ALTER TABLE [dbo].[PartTimeEntryLoads] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_PartTimeEntryLoads_PartTimeDisciplines_PartTimeDisciplineId] FOREIGN KEY([PartTimeDisciplineId]) REFERENCES[dbo].[PartTimeDisciplines]([Id]); ";

            await connection.QueryAsync(dropConstantQuery);
            await connection.QueryAsync(truncateQuery);
            await connection.QueryAsync(addConstantQuery);
        }

        private async Task<IDbConnection> OpenConnection()
        {
            var connection = new SqlConnection(this._connectionString);
            await connection.OpenAsync();

            return connection;
        }
    }
}