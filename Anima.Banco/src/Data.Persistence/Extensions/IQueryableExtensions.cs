using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Anima.Banco.Infrastructure.Data.Persistence.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> JoinByExpression<TEntity>(this IQueryable<TEntity> queryable, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {            
            foreach (var i in includes)
            {
                queryable = queryable.Include(i);
            }

            return queryable;
        }

        public static IQueryable<TEntity> JoinByString<TEntity>(this IQueryable<TEntity> queryable, params string[] includes) where TEntity : class
        {            
            foreach (var i in includes)
            {
                queryable = queryable.Include(i);
            }

            return queryable;
        }
    }
}
