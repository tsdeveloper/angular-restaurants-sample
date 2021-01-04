using System;

namespace Restaurant.Core.Specification.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        int Complete();
    }
}