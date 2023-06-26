using Devsu.Core.Entities;

namespace Devsu.Core.Contracts.Repositories
{
    public interface IMovimientoRepository : IGenericRepository<Movimiento>
    {
        List<Movimiento> ListarMovimientosPorActualizarLimite();
        Task<Movimiento?> ObtenerUltimoMovimientoPorIdCuenta(int idCuenta);
    }
}
