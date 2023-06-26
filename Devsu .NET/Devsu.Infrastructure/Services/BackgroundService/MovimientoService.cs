using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Devsu.Infrastructure.Services.BackgroundService
{
    public class MovimientoService : Microsoft.Extensions.Hosting.BackgroundService
    {
        private readonly ILogger<MovimientoService> _logger;
        private readonly IServiceProvider serviceProvider;

        public MovimientoService(ILogger<MovimientoService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            this.serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new(TimeSpan.FromDays(1));
            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    await ActualizarLimiteDiarioMovimiento();
                }
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogWarning("Se detuvo la tarea que actualiza el limite diario del movimiento: {Message}", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió un error inesperado al ejecutar la tarea que actualiza el limite diario del movimiento: {Message} - {StackTrace}.", ex.Message, ex.StackTrace);
            }
        }

        private async Task ActualizarLimiteDiarioMovimiento()
        {
            using IServiceScope serviceScope = serviceProvider.CreateScope();
            IMovimientoRepository movimientoRepository = serviceScope.ServiceProvider.GetRequiredService<IMovimientoRepository>();

            var movimientos = movimientoRepository.ListarMovimientosPorActualizarLimite();
            foreach (var movimiento in movimientos)
            {
                movimiento.Limite = Movimiento.LIMITE_DIARIO;
            }

            await movimientoRepository.GuardarCambios();
        }
    }
}
