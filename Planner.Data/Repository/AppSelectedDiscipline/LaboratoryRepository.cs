﻿using Planner.Data.GenericRepository;
using Planner.Entities.Domain.AppSelectedDiscipline;
using Planner.RepositoryInterfaces.ObjectInterfaces.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.Data.Repository.AppSelectedDiscipline
{
    public class LaboratoryRepository : GenericRepository<Laboratory>, ILaboratoryRepository
    {
        public LaboratoryRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

        public async Task<int> InsertLaboratory(Laboratory laboratory) => await this.Insert(laboratory);
    }
}