using Planner.Entities.Domain.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Interfaces.AppSelectedDiscipline
{
    public interface ILaboratoryRepository
    {
        Task<int> InsertLaboratory(Laboratory laboratory);
    }
}