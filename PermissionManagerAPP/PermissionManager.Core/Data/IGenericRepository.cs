﻿using PermissionManager.Core.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.Core.Data
{
    public interface IGenericRepository<TEntity>
    where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetPaginated(int page, int size);

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
