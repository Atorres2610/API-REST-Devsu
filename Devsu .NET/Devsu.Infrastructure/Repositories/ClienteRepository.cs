using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Entities;
using Devsu.Infrastructure.Data;

namespace Devsu.Infrastructure.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DevsuContext context) : base(context) { }
    }
}
