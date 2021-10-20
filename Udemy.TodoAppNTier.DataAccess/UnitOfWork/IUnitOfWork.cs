using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.DataAccess.Interfaces;
using Udemy.TodoAppNTier.Entities.Domains;

namespace Udemy.TodoAppNTier.DataAccess.UnitOfWork
{
   public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T :BaseEntity, new();
        Task SaveChangesAsync();
    }
}
