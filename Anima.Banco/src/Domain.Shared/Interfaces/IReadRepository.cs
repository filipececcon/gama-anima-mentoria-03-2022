using System;
using System.Linq;
using System.Linq.Expressions;
using Anima.Banco.Domain.Shared.Entities;

namespace Anima.Banco.Domain.Shared.Interfaces
{
    public interface IReadRepository
    {
        IQueryable<TEntity> AsQueryable<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : Entity;

        IQueryable<TEntity> AsQueryable<TEntity>(params string[] includes) where TEntity : Entity;
    }
}
