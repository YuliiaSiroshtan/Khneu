using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppEntryLoad;
using Planner.Entities.Domain.AppEntryLoad.FullTime;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
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
