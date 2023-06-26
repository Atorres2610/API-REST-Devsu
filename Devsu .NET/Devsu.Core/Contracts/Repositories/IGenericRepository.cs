using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Devsu.Core.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Actualizar(T entidad);

        Task GuardarCambios();

        Task Insertar(T entidad);

        Task<List<T>> Listar(Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null, bool disableTracking = true);

        Task<T?> Obtener(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null, bool disableTracking = true);

        Task<bool> ValidarExistencia(Expression<Func<T, bool>> predicate);
    }
}
