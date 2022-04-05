using System;
using System.Linq;
using System.Linq.Expressions;
using Anima.Banco.Domain.Shared.Entities;

namespace Anima.Banco.Domain.Shared.Interfaces
{
    public interface IReadRepository
    {
        IQueryable<TEntity> AsQueryable<TEntity>() where TEntity : Entity;
    }
}
