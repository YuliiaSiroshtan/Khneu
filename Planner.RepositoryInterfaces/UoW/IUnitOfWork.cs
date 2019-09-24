using Planner.RepositoryInterfaces.ObjectInterfaces;
using System;

namespace Planner.RepositoryInterfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }
        INdrRepository NdrRepository { get; set; }
        INMBDRepository NMBDRepository { get; set; }
        IPublicationRepositpry PublicationRepositpry { get; set; }
        IPlanTrainingRepository PlanTrainingRepository { get; set; }
        IIndivPlanFieldsRepository IndivPlanFieldsRepository { get; set; }
        IIndivPlanFieldsValueRepository IndivPlanFieldsValueRepository { get; set; }
        IDayEntryLoadRepository DayEntryLoadRepository { get; set; }
        Int32 SaveChanges();
    }
}
