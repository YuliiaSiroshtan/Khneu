﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.RepositoryInterfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetEntities();

        Task DeleteEntity(int id);

        Task<T> GetEntityById(int id);

        Task<T> GetEntityByName(string name);

        Task Update(T entity);

        Task<int> Insert(T entity);
    }
}