using Planner.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface INMBDRepository
    {
        IEnumerable<NMBD> GetAllNMBD();
        NMBD GetById(String id);
    }
}
