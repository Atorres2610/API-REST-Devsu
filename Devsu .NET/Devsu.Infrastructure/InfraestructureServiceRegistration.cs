using Devsu.Core.Contracts.Queries;
using Devsu.Core.Contracts.Repositories;
using Devsu.Infrastructure.Data;
using Devsu.Infrastructure.Queries;
using Devsu.Infrastructure.Repositories;
using Devsu.Infrastructure.Services.BackgroundService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devsu.Infrastructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DevsuContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            services.AddScoped<IReporteQuery, ReporteQuery>();
            services.AddHostedService<MovimientoService>();
            return services;
        }
    }
}
