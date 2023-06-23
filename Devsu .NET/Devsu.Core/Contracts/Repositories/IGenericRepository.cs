using Microsoft.EntityFrameworkCore.Query;

namespace Devsu.Core.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task Insertar(T entidad);

        Task<T?> Obtener(int id);

        Task<List<T>> Listar(Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null, bool disableTracking = true);

        Task GuardarCambios();
    }
}
