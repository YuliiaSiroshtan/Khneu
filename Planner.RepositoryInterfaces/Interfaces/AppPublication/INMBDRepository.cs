using Planner.Entities.Domain;
using Planner.Entities.Domain.AppPublication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppPublication
{
    public interface INMBDRepository
    {
        Task<IEnumerable<NMBD>> GetAllNMBD();
        //NMBD GetById(String id);
    }
}
