using Planner.Entities.Domain.UniversityUnits;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.UniversityUnits
{
    public interface IFacultyRepository
    {
        Task<IEnumerable<Faculty>> GetFaculties();

        Task DeleteFaculty(int id);

        Task<Faculty> GetFacultyById(int id);

        Task<Faculty> GetFacultyByName(string name);

        Task UpdateFaculty(Faculty faculty);

        Task<int> InsertFaculty(Faculty faculty);
    }
}
