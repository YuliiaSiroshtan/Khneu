using System.Threading.Tasks;
using Planner.Entities.DTO.AppUserDto;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface  IRateService
    {
        Task DeleteRate(int id);

        Task UpdateRate(RateDto rateDto);

        Task<int> InsertRate(RateDto rateDto);
    }
}
