using Planner.Entities.DTO.AppSelectedDisciplineDto;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppSelectedDiscipline
{
    public interface ILaboratoryService
    {
        Task<int> InsertLaboratory(LaboratoryDto laboratoryDto);
    }
}