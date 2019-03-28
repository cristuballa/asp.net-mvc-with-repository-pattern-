using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly InventoryDBContext _dbContext;

        public Repository(InventoryDBContext dbContext)
        {
           _dbContext = dbContext;
        }


        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();

        }
        public T GetbyId(int id)
        {
            return _dbContext.Set<T>().Find(id);

        }


        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().SingleOrDefault(predicate);
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

    }
}
