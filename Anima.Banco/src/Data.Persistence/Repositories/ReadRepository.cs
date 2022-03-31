using System;
using System.Linq;
using System.Linq.Expressions;
using Anima.Banco.Domain.Shared.Entities;
using Anima.Banco.Domain.Shared.Interfaces;
using Anima.Banco.Infrastructure.Data.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Anima.Banco.Infrastructure.Data.Persistence.Repositories
{
    public class ReadRepository : IReadRepository
    {
        private AnimaContext _context;

        public ReadRepository(AnimaContext context)  
        {
            _context = context;
        }

        public IQueryable<TEntity> AsQueryable<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : Entity
        {
            return _context.Set<TEntity>().AsNoTracking();                
        }

        public IQueryable<TEntity> AsQueryable<TEntity>(params string[] includes) where TEntity : Entity
        {
            var db = _context.Set<TEntity>().AsNoTracking().AsQueryable();

            foreach (var i in includes)
            {
                db = db.Include(i);
            }

            return db;
        }
    }
}
