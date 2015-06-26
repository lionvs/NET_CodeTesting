using System;
using System.Collections.Generic;
using System.Linq;
using Cashbox.DataAccess;

namespace Cashbox.Tests.Fake
{
    public class FakeRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IList<T> _data;

        public FakeRepository(params T[] data)
        {
            _data = data;
        }

        public IQueryable<T> Query()
        {
            return _data.AsQueryable();
        }

        public IEnumerable<T> All()
        {
            return _data;
        }

        public T Get(int id)
        {
            return _data.FirstOrDefault(x => x.Id == id);
        }

        public T Get(Func<T, bool> predicate)
        {
            return _data.FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            _data.Add(entity);
        }

        public void Attach(T entity)
        {
        }

        public void Delete(T entity)
        {
            _data.Remove(entity);
        }
    }
}