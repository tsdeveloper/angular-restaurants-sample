using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Infra.Data
{
    public class AppStoreContext : DbContext
    {
        public AppStoreContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder m)
        {
            base.OnModelCreating(m);
            m.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
    
    public static class ContextAppExtensions {
        public static DbSet<TEntityType> DbSet<TEntityType> (this AppStoreContext context)
            where TEntityType : class {
            return context.Set<TEntityType> ();
        }
    }
}