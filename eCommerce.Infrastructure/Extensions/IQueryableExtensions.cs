﻿using System.Linq.Expressions;

namespace eCommerce.Infrastructure.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, bool condition, Expression<Func<T, bool>> predicate)
    {
        if (condition)
        {
            return queryable.Where(predicate);
        }

        return queryable;
    }
}
