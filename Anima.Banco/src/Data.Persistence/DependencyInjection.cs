using System;
using Anima.Banco.Domain.Shared.Interfaces;
using Anima.Banco.Infrastructure.Data.Persistence.Contexts;
using Anima.Banco.Infrastructure.Data.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anima.Banco.Infrastructure.Data.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureData(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AnimaDb");

            services.AddDbContext<AnimaContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IWriteRepository, WriteRepository>();

            return services;
        }
    }
}
