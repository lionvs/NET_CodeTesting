using System;
using System.Linq;

namespace Cashbox.DataAccess
{
    internal interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> Query();
        T Get(int id);
        T Get(Func<T, bool> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}