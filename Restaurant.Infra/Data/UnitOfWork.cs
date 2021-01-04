using System;
using System.Collections;
using Restaurant.Core.Specification.Interfaces;
using Restaurant.Infra.Repository;

namespace Restaurant.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppStoreContext _context;
        private Hashtable _repositories;

        public UnitOfWork(AppStoreContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if(_repositories == null) _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>) _repositories[type];
        }

        public int Complete()
        {
            try
            {
                return  _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
         
        }
    }
}