using System;
using System.Data.Entity;
using System.Linq;

namespace Cashbox.DataAccess
{
    internal class DbRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext DataContext;
        protected readonly DbSet<T> DataSet;

        public DbRepository(DbContext dataContext)
        {
            DataContext = dataContext;
            DataSet = dataContext.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return DataSet;
        }

        public T Get(int id)
        {
            return DataSet.FirstOrDefault(x => x.Id == id);
        }

        public T Get(Func<T, bool> predicate)
        {
            return DataSet.FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            DataSet.Add(entity);
        }

        public void Update(T entity)
        {
            DataSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            DataSet.Remove(entity);
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }
    }
}
