using Devsu.Core.Contracts.Queries;
using Devsu.Core.Contracts.Repositories;
using Devsu.Infrastructure.Data;
using Devsu.Infrastructure.Queries;
using Devsu.Infrastructure.Repositories;
using Devsu.Infrastructure.Services.BackgroundService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Devsu.Infrastructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            if (environment.IsDevelopment() || environment.IsProduction())
            {
                services.AddDbContext<DevsuContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });
                services.AddHostedService<MovimientoService>();
            }
            else
            {
                //Conexión SQLite para pruebas de integración
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(folder);
                var dbPath = Path.Join(path, "devsu.db");
                services.AddDbContext<DevsuContext>(opt => opt.UseSqlite($"Data Source={dbPath}"));
            }

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            services.AddScoped<IReporteQuery, ReporteQuery>();
            return services;
        }
    }
}
