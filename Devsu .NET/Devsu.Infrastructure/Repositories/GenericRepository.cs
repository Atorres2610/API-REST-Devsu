using Devsu.Core.Contracts.Repositories;
using Devsu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Devsu.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DevsuContext context;
        private readonly DbSet<T> table;

        public GenericRepository(DevsuContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public async Task GuardarCambios()
        {
            await context.SaveChangesAsync();
        }

        public async Task Insertar(T entidad)
        {
            await context.AddAsync(entidad);
        }

        public async Task<List<T>> Listar(Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null, bool disableTracking = true)
        {
            IQueryable<T> query = table;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include is not null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> Obtener(int id)
        {
            return await table.FindAsync(id);
        }
    }
}
