using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.RepositoryInterfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        void Remove(T item);
        void InsertOrUpdateGraph(T item);
        T GetById(Object id);
        IEnumerable<T> GetAll();
        Int32 SaveChanges();
    }
}
