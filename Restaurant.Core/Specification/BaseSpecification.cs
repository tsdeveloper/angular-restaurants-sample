using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Restaurant.Core.Specification.Interfaces;

namespace Restaurant.Core.Specification
{
    public class BaseSpecification<T> : IBaseSpecification<T>
    {
        public BaseSpecification()
        {
            
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public IReadOnlyList<T> ListAsync(IBaseSpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public void AddInclude(Expression<Func<T, object>> includes)
        {
            Includes.Add(includes);
        }
        
        public void AddOrderBy(Expression<Func<T, object>> orderBy)
        {
            OrderBy = orderBy;
        }
        
        public void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
        {
            OrderByDescending = orderByDescending;
        }
    }
}