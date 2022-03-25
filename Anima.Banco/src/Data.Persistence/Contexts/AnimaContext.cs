using System;
using Anima.Banco.Domain.Core.Entities;
using Anima.Banco.Infrastructure.Data.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Anima.Banco.Infrastructure.Data.Persistence.Contexts
{
    public class AnimaContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public AnimaContext()
        {

        }

        public AnimaContext(DbContextOptionsBuilder builder) : base(builder.Options)
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
    }
}
