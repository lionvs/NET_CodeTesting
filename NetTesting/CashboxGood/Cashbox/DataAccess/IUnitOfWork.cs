using System;

namespace Cashbox.DataAccess
{
    internal interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class, IEntity;
        void SaveChanges();
    }
}
