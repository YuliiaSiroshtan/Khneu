using Microsoft.EntityFrameworkCore;
using Planner.Data.Context;
using Planner.RepositoryInterfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Data.BaseRepository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<T> GetById(object id) => await _entities.FindAsync(id);

        protected IQueryable<T> Query => _entities;

        public void InsertOrUpdateGraph(T item) => _context.Update(item);

        public void Remove(T item) => _context.Remove(item);

        public async Task<IEnumerable<T>> GetAll() => await _entities.ToListAsync();

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();
    }
}
