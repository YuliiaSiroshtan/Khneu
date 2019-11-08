using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.RepositoryInterfaces.ObjectInterfaces;

namespace Planner.Data.Repository
{
    public class EntryLoadsPropertyRepository : GenericRepository<EntryLoadsProperty>, IEntryLoadsPropertyRepository
    {
        public EntryLoadsPropertyRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        public async Task<IEnumerable<EntryLoadsProperty>> GetEntryLoadsProperties() => await GetEntities();

        public async Task DeleteEntryLoadsProperty(int id) => await DeleteEntity(id);


        public async Task<EntryLoadsProperty> GetEntryLoadsPropertyById(int id) => await GetEntityById(id);


        public async Task<EntryLoadsProperty> GetEntryLoadsPropertyByName(string name) => await GetEntityByName(name);


        public async Task UpdateEntryLoadsProperty(EntryLoadsProperty entryLoadsProperty) =>
            await Update(entryLoadsProperty);

        public async Task<int> InsertEntryLoadsProperty(EntryLoadsProperty entryLoadsProperty) =>
            await Insert(entryLoadsProperty);

        public async Task RecreateTables()
        {
            var connection = await OpenConnection();

            const string dropConstantQuery =
                "ALTER TABLE [dbo].[FullTimeEntryLoads] " +
                "DROP CONSTRAINT [FK_FullTimeEntryLoads_Disciplines_DisciplineId];" +
                "ALTER TABLE[dbo].[FullTimeEntryLoads] " +
                "DROP CONSTRAINT[FK_FullTimeEntryLoads_Faculties_FacultyId];" +
                "ALTER TABLE [dbo].[Disciplines] " +
                "DROP CONSTRAINT FK_Disciplines_Departments_DepartmentId;" +
                "ALTER TABLE[dbo].[Disciplines] " +
                "DROP CONSTRAINT FK_Disciplines_FirstSemesters_FirstSemesterId;" +
                "ALTER TABLE[dbo].[Disciplines] " +
                "DROP CONSTRAINT FK_Disciplines_SecondSemesters_SecondSemesterId;" +
                "ALTER TABLE [dbo].[PartTimeEntryLoads] " +
                "DROP CONSTRAINT [FK_PartTimeEntryLoads_PartTimeDisciplines_PartTimeDisciplineId];" +
                "ALTER TABLE [dbo].[PartTimeDisciplines] " +
                "DROP CONSTRAINT [FK_PartTimeDisciplines_ConstituentSessions_ConstituentSessionId];" +
                "ALTER TABLE [dbo].[PartTimeDisciplines] " +
                "DROP CONSTRAINT [FK_PartTimeDisciplines_Departments_DepartmentId];" +
                "ALTER TABLE [dbo].[PartTimeDisciplines] " +
                "DROP CONSTRAINT [FK_PartTimeDisciplines_ExaminationSessions_ExaminationSessionId];";


            const string truncateQuery = "TRUNCATE TABLE [dbo].[FullTimeEntryLoads];" +
                                         "TRUNCATE TABLE [dbo].[FirstSemesters];" +
                                         "TRUNCATE TABLE [dbo].[SecondSemesters];" +
                                         "TRUNCATE TABLE [dbo].[Disciplines];" +
                                         "TRUNCATE TABLE [dbo].[PartTimeDisciplines];" +
                                         "TRUNCATE TABLE [dbo].[PartTimeEntryLoads];" +
                                         "TRUNCATE TABLE [dbo].[ConstituentSessions];" +
                                         "TRUNCATE TABLE [dbo].[ExaminationSessions];";

            const string addConstantQuery = "ALTER TABLE [dbo].[Disciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT [FK_Disciplines_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] " +
                                            "ALTER TABLE [dbo].[Disciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_Disciplines_FirstSemesters_FirstSemesterId] FOREIGN KEY([FirstSemesterId]) REFERENCES[dbo].[FirstSemesters]([Id]);" +
                                            "ALTER TABLE [dbo].[Disciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_Disciplines_SecondSemesters_SecondSemesterId] FOREIGN KEY([SecondSemesterId]) REFERENCES[dbo].[SecondSemesters]([Id]);" +
                                            "ALTER TABLE [dbo].[FullTimeEntryLoads] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_FullTimeEntryLoads_Disciplines_DisciplineId] FOREIGN KEY([DisciplineId]) REFERENCES[dbo].[Disciplines]([Id]);" +
                                            "ALTER TABLE [dbo].[FullTimeEntryLoads] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_FullTimeEntryLoads_Faculties_FacultyId] FOREIGN KEY([FacultyId]) REFERENCES[dbo].[Faculties]([Id]);" +
                                            "ALTER TABLE [dbo].[PartTimeDisciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_PartTimeDisciplines_ConstituentSessions_ConstituentSessionId] FOREIGN KEY([ConstituentSessionId]) REFERENCES[dbo].[ConstituentSessions]([Id]);" +
                                            "ALTER TABLE [dbo].[PartTimeDisciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_PartTimeDisciplines_Departments_DepartmentId] FOREIGN KEY([DepartmentId]) REFERENCES[dbo].[Departments]([Id]); " +
                                            "ALTER TABLE [dbo].[PartTimeDisciplines] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_PartTimeDisciplines_ExaminationSessions_ExaminationSessionId] FOREIGN KEY([ExaminationSessionId]) REFERENCES[dbo].[ExaminationSessions]([Id]); " +
                                            "ALTER TABLE [dbo].[PartTimeEntryLoads] WITH NOCHECK " +
                                            "ADD CONSTRAINT[FK_PartTimeEntryLoads_PartTimeDisciplines_PartTimeDisciplineId] FOREIGN KEY([PartTimeDisciplineId]) REFERENCES[dbo].[PartTimeDisciplines]([Id]); ";

            await connection.QueryAsync(dropConstantQuery);
            await connection.QueryAsync(truncateQuery);
            await connection.QueryAsync(addConstantQuery);
        }

    }
}
