using System;
using System.Linq;
using System.Linq.Expressions;
using Anima.Banco.Domain.Shared.Entities;

namespace Anima.Banco.Domain.Shared.Interfaces
{
    public interface IWriteRepository
    {
        IQueryable<TEntity> AsQueryable<TEntity>() where TEntity : Entity;

        void Add<TEntity>(TEntity entity) where TEntity : Entity;

        void Remove<TEntity>(Guid id) where TEntity : Entity;

        void Commit();
    }
}
