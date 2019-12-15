using Planner.Entities.Domain.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.UniversityUnits
{
    public interface IFacultyRepository
    {
        Task<IEnumerable<Faculty>> GetFaculties();

        Task<Faculty> GetFacultyById(int id);

        Task<Faculty> GetFacultyByName(string name);
    }
}