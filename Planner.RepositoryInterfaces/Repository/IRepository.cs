using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        void Remove(T item);
        void InsertOrUpdateGraph(T item);
        Task<T> GetById(object id);
        Task<IEnumerable<T>> GetAll();
        Task<int> SaveChanges();
    }
}
