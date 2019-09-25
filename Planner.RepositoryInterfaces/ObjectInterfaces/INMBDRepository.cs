﻿using Planner.Entities.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface INMBDRepository
    {
        Task<IEnumerable<NMBD>> GetAllNMBD();
        Task<NMBD> GetById(string id);
    }
}
