using Devsu.Core.Contracts.Repositories;
using Devsu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Devsu.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DevsuContext Context { get; set; }
        public DbSet<T> Table { get; set; }

        public GenericRepository(DevsuContext context)
        {
            Context = context;
            Table = context.Set<T>();
        }

        public async Task GuardarCambios()
        {
            await Context.SaveChangesAsync();
        }

        public void Actualizar(T entidad)
        {
            Context.Update(entidad);
        }

        public async Task<bool> ValidarExistencia(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task Insertar(T entidad)
        {
            await Context.AddAsync(entidad);
        }

        public async Task<List<T>> Listar(Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null, bool disableTracking = true)
        {
            IQueryable<T> query = Table;
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

        public async Task<T?> Obtener(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null, bool disableTracking = true)
        {
            IQueryable<T> query = Table;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include is not null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(predicate: predicate);
        }
    }
}
