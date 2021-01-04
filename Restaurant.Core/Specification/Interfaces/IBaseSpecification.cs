using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Restaurant.Core.Specification.Interfaces
{
    public interface IBaseSpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        
        IReadOnlyList<T> ListAsync(IBaseSpecification<T> spec);

    }
}