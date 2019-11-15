using Planner.Entities.DTO.AppUserDto;
using System.Threading.Tasks;

namespace Planner.ServiceInterfaces.Interfaces.AppUser
{
    public interface IRateService
    {
        Task DeleteRate(int id);

        Task UpdateRate(RateDto rateDto);

        Task<int> InsertRate(RateDto rateDto);
    }
}
