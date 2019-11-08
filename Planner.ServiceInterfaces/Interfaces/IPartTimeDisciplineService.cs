using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Entities.DTO;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface IPartTimeDisciplineService
    {
        Task<IEnumerable<PartTimeDisciplineDto>> GetPartTimeDisciplines();

        Task DeletePartTimeDiscipline(int id);

        Task<PartTimeDisciplineDto> GetPartTimeDisciplineById(int id);

        Task<PartTimeDisciplineDto> GetPartTimeDisciplineByName(string name);

        Task UpdatePartTimeDiscipline(PartTimeDisciplineDto partTimeDisciplineDto);

        Task<int> InsertPartTimeDiscipline(PartTimeDisciplineDto partTimeDisciplineDto);
    }
}
