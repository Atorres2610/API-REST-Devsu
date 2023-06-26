using Devsu.Core.Features.Reporte.Queries;

namespace Devsu.Core.Contracts.Queries
{
    public interface IReporteQuery
    {
        Task<IEnumerable<EstadoCuentaResponse>> EstadoCuenta(int idCliente, DateTime? fechaInicio, DateTime? fechaFin);
    }
}
