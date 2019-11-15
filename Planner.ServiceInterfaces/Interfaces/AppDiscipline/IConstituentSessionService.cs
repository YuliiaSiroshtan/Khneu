using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppDiscipline
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
