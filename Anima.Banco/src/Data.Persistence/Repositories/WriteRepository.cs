using System;
using System.Linq;
using System.Linq.Expressions;
using Anima.Banco.Domain.Shared.Entities;
using Anima.Banco.Domain.Shared.Interfaces;
using Anima.Banco.Infrastructure.Data.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Anima.Banco.Infrastructure.Data.Persistence.Repositories
{
    public class WriteRepository : IWriteRepository
    {
        private AnimaContext _context;

        public WriteRepository(AnimaContext context)
        {
            _context = context;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : Entity
        {
            _context.Set<TEntity>().Add(entity);            
        }

        public IQueryable<TEntity> AsQueryable<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : Entity
        {
            var db = _context.Set<TEntity>().AsQueryable();

            foreach (var i in includes)
            {
                db = db.Include(i);
            }

            return db;
        }

        public IQueryable<TEntity> AsQueryable<TEntity>(params string[] includes) where TEntity : Entity
        {
            var db = _context.Set<TEntity>().AsQueryable();

            foreach (var i in includes)
            {
                db = db.Include(i);
            }

            return db;
        }



        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Remove<TEntity>(Guid id) where TEntity : Entity
        {
            var table = _context.Set<TEntity>();

            var entity = table.Find(id);

            table.Remove(entity);
        }
    }
}
