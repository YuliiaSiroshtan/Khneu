using Planner.Data.Context;
using Planner.Data.Repository;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using Planner.RepositoryInterfaces.UoW;
using System.Threading.Tasks;

namespace Planner.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IUserRepository UserRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        public INdrRepository NdrRepository { get; set; }
        public INMBDRepository NMBDRepository { get; set; }
        public IPublicationRepository PublicationRepository { get; set; }
        public IPlanTrainingRepository PlanTrainingRepository { get; set; }
        public IIndividualPlanFieldsRepository IndividualPlanFieldsRepository { get; set; }
        public IIndividualPlanFieldsValueRepository IndividualPlanFieldsValueRepository { get; set; }
        public IDayEntryLoadRepository DayEntryLoadRepository { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            UserRepository = new UserRepository(_context);
            RoleRepository = new RoleRepository(_context);
            NdrRepository = new NdrRepository(_context);
            NMBDRepository = new NMBDRepository(_context);
            PublicationRepository = new PublicationRepository(_context);
            PlanTrainingRepository = new PlanTrainingJobRepository(_context);
            IndividualPlanFieldsRepository = new IndividualPlanFieldRepository(_context);
            IndividualPlanFieldsValueRepository = new IndividualPlanFieldsValueRepository(_context);
            DayEntryLoadRepository = new DayEntryLoadRepository(_context);
        }

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();

        public ValueTask DisposeAsync() => _context.DisposeAsync();
    }
}
