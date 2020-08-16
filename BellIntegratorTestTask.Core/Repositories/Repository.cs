using BellIntegratorTestTask.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BellIntegratorTestTask.Core.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private static int contextint;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            Random rnd = new Random();
            contextint = rnd.Next();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _dbContext.Set<TEntity>().Find(keyValues);
        }

        public virtual IEnumerable<TEntity> List()
        {
            return _dbContext.Set<TEntity>().AsEnumerable();
        }

        public virtual IEnumerable<TEntity> List(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>()
                   .Where(predicate)
                   .AsEnumerable();
        }

        public void Insert(TEntity entity)
        {
            Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var dbset = _dbContext.Set<TEntity>();
            var entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Attach(entity);
            }
            dbset.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(object id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            Delete(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbContext.Set<TEntity>();
        }

        private void Attach(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.Set<TEntity>().Attach(entity);
            }
        }
    }
}
