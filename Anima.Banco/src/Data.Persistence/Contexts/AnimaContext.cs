using System;
using System.Linq;
using Anima.Banco.Domain.Core.Entities;
using Anima.Banco.Domain.Shared.Entities;
using Anima.Banco.Infrastructure.Data.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Anima.Banco.Infrastructure.Data.Persistence.Contexts
{
    public class AnimaContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public AnimaContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public AnimaContext(string connectionString) : base(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            ChangeTracker
                .Entries()
                .Where(t => t.State == EntityState.Modified)
                .Select(t => t.Entity as Entity)
                .AsParallel()
                .ForAll(entity => entity.UpdatedAt = DateTime.Now);

            return base.SaveChanges();
        }
    }
}
