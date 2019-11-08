using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.Domain.AppEntryLoad.PartTime;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
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
