using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T GetbyId(int id);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
    }
}