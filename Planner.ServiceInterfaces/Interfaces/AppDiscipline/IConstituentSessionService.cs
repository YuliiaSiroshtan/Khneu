using Planner.Entities.DTO.AppEntryLoadDto.PartTime;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppDiscipline
{
    public interface IConstituentSessionService
    {
        Task<int> InsertConstituentSession(ConstituentSessionDto constituentSessionDto);
    }
}
