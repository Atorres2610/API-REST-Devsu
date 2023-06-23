using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Entities;
using Devsu.Infrastructure.Data;

namespace Devsu.Infrastructure.Repositories
{
    internal class MovimientoRepository : GenericRepository<Movimiento>, IMovimientoRepository
    {
        public MovimientoRepository(DevsuContext context) : base(context)
        {
        }
    }
}
