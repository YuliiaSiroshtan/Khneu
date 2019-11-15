﻿using Planner.Entities.Domain.AppEntryLoad.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline
{
    public interface IPartTimeDisciplineRepository
    {
        Task<IEnumerable<PartTimeDiscipline>> GetPartTimeDisciplines();

        Task<IEnumerable<PartTimeDiscipline>> GetPartTimeDisciplinesByDepartmentId(int id);

        Task DeletePartTimeDiscipline(int id);

        Task<PartTimeDiscipline> GetPartTimeDisciplineById(int id);

        Task<PartTimeDiscipline> GetPartTimeDisciplineByName(string name);

        Task UpdatePartTimeDiscipline(PartTimeDiscipline partTimeDiscipline);

        Task<int> InsertPartTimeDiscipline(PartTimeDiscipline partTimeDiscipline);
    }
}