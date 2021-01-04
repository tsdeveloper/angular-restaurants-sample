using System.Collections.Generic;

namespace Restaurant.Core.Specification.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetEntityWithSpec(IBaseSpecification<T> spec);
        IReadOnlyList<T> ListAsync(IBaseSpecification<T> spec);
        void Add(T entity);
        /*void Update(T entity);
        void Delete(T entity);*/
    }
}