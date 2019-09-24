using Microsoft.EntityFrameworkCore;
using Planner.Data.Context;
using Planner.RepositoryInterfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Planner.Data.BaseRepository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public AppDbContext context;
        private DbSet<T> entities;

        public BaseRepository(AppDbContext _context)
        {
            context = _context;
            entities = context.Set<T>();
        }

        public T GetById(object id)
        {
            return entities.Find(id);
        }

        public IQueryable<T> Query
        {
            get
            {
                return entities;
            }
        }

        public void InsertOrUpdateGraph(T item)
        {
            context.Update(item);
        }

        public void Remove(T item)
        {
            context.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public Int32 SaveChanges()
        {
            return context.SaveChanges();
        }


    }
}
