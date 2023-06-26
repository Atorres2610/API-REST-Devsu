using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Entities;
using Devsu.Infrastructure.Data;

namespace Devsu.Infrastructure.Repositories
{
    public class CuentaRepository : GenericRepository<Cuenta>, ICuentaRepository
    {
        public CuentaRepository(DevsuContext context) : base(context) { }
    }
}