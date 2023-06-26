using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Entities;
using Devsu.Infrastructure.Data;
using Devsu.Util.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Devsu.Infrastructure.Repositories
{
    internal class MovimientoRepository : GenericRepository<Movimiento>, IMovimientoRepository
    {
        public MovimientoRepository(DevsuContext context) : base(context) { }

        public List<Movimiento> ListarMovimientosPorActualizarLimite()
        {
            DateTime fechaActual = DateTimeHelper.PeruDateTime.Date;
            return Context.Movimiento.FromSqlRaw("EXEC sp_ListarMovimientosPorActualizarLimite {0}", fechaActual).IgnoreQueryFilters().ToList();
        }

        public async Task<Movimiento?> ObtenerUltimoMovimientoPorIdCuenta(int idCuenta)
        {
            return await Context.Movimiento.Where(m => m.IdCuenta == idCuenta).OrderByDescending(m => m.IdMovimiento).FirstOrDefaultAsync();
        }
    }
}
