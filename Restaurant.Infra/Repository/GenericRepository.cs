using System.Collections.Generic;
using System.Linq;
using Restaurant.Core.Specification;
using Restaurant.Core.Specification.Interfaces;
using Restaurant.Infra.Data;

namespace Restaurant.Infra.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppStoreContext _context;

        public GenericRepository(AppStoreContext context)
        {
            _context = context;
        }
        public T GetEntityWithSpec(IBaseSpecification<T> spec)
        {
            return ApplySpecification(spec).FirstOrDefault();
        }

        public IReadOnlyList<T> ListAsync(IBaseSpecification<T> spec)
        {
            return ApplySpecification(spec).ToList();
        }

        public void Add(T entity)
        {
            _context.DbSet<T>().Add(entity);
        }


        private IQueryable<T> ApplySpecification(IBaseSpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.DbSet<T>().AsQueryable(), spec);
        }
    }
}