﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Entities.Domains;

namespace Udemy.TodoAppNTier.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter,bool asNoTracking=false);
        Task CreateAsync(T entity);
        void UpdateAsync(T entity);
        void RemoveAsync(int id);

        IQueryable<T> GetQuery();
    }
}
