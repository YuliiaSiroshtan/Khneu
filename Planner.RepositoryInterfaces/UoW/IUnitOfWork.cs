using Planner.RepositoryInterfaces.ObjectInterfaces;
using System;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }
        INdrRepository NdrRepository { get; set; }
        INMBDRepository NMBDRepository { get; set; }
        IPublicationRepository PublicationRepository { get; set; }
        IPlanTrainingRepository PlanTrainingRepository { get; set; }
        IIndividualPlanFieldsRepository IndividualPlanFieldsRepository { get; set; }
        IIndividualPlanFieldsValueRepository IndividualPlanFieldsValueRepository { get; set; }
        IDayEntryLoadRepository DayEntryLoadRepository { get; set; }

        Task<int> SaveChanges();
    }
}
