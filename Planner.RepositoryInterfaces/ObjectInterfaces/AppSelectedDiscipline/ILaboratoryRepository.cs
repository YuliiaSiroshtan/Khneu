using Planner.Entities.Domain.AppSelectedDiscipline;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.ObjectInterfaces.AppSelectedDiscipline
{
    public interface ILaboratoryRepository
    {
        Task<int> InsertLaboratory(Laboratory laboratory);
    }
}