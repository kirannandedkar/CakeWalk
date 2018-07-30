using CakeWalk.Model.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CakeWalk.Model.Repository
{
    public abstract partial class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity, TContext>
          where TEntity : class
        where TContext : DbContext, new()
    {
        protected TContext dataContext = new TContext();

        /// <summary>
        /// Get All the record
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll()
        {
            return dataContext.Set<TEntity>();
        }
        /// <summary>
        /// GetBy
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public TEntity GetBy(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");

            TEntity entity = dataContext.Set<TEntity>().FirstOrDefault(filter);
            if (entity == null)
                return default(TEntity);

            return entity;
        }
        /// <summary>
        /// AddNew
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //public TEntity AddNew(TEntity entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException("entity");

        //    dataContext.Entry(entity).State = System.Data.Entity.EntityState.Added;
        //    dataContext.SaveChanges();
        //    return entity;
        //}
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //public TEntity Update(TEntity entity)
        //{
        //    dataContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        //    dataContext.SaveChanges();
        //    return entity;
        //}
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        //public void Delete(TEntity entity)
        //{
        //    dataContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        //    dataContext.SaveChanges();
        //}

        public IQueryable<TEntity> GetByAll(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");

            return dataContext.Set<TEntity>().Where(filter);

        }

        public bool GetifAny(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");

            return dataContext.Set<TEntity>().Any(filter);

        }
    }
 }
