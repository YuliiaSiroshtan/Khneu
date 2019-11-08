using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IConstituentSessionService
    {
        Task<IEnumerable<ConstituentSessionDto>> GetConstituentSessions();

        Task DeleteConstituentSession(int id);

        Task<ConstituentSessionDto> GetConstituentSessionById(int id);

        Task UpdateConstituentSession(ConstituentSessionDto constituentSessionDto);

        Task<int> InsertConstituentSession(ConstituentSessionDto constituentSessionDto);
    }
}
