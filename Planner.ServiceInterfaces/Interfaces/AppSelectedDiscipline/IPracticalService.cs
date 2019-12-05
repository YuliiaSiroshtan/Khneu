using Planner.Entities.DTO.AppSelectedDisciplineDto;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline
{
    public interface IPracticalService
    {
        Task<int> InsertPractical(PracticalDto practicalDto);
    }
}