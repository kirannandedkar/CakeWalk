using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CakeWalk.Model.Repository.Interface
{
    public interface IBaseRepository<TEntity, TContext>
      where TContext : DbContext, new()
    {
        IQueryable<TEntity> GetAll();
        TEntity GetBy(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetByAll(Expression<Func<TEntity, bool>> filter);
        
        bool GetifAny(Expression<Func<TEntity, bool>> filter);
        
    }
}
