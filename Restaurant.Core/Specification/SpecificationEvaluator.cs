using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Specification.Interfaces;

namespace Restaurant.Core.Specification
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IBaseSpecification<T> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
                query = inputQuery.Where(spec.Criteria);

            if (spec.OrderBy != null)
                query = inputQuery.OrderBy(spec.OrderBy);

            if (spec.OrderByDescending != null)
                query = inputQuery.OrderByDescending(spec.OrderByDescending);

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}