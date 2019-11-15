using Planner.Entities.Domain.AppEntryLoad.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppDiscipline
{
    public interface IConstituentSessionRepository
    {
        Task<IEnumerable<ConstituentSession>> GetConstituentSessions();

        Task DeleteConstituentSession(int id);

        Task<ConstituentSession> GetConstituentSessionById(int id);

        Task UpdateConstituentSession(ConstituentSession constituentSession);

        Task<int> InsertConstituentSession(ConstituentSession constituentSession);
    }
}
