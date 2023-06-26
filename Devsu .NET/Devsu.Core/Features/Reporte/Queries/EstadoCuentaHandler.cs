using Devsu.Core.Contracts.Queries;
using Devsu.Core.Models;
using MediatR;
using System.Net;

namespace Devsu.Core.Features.Reporte.Queries
{
    public class EstadoCuentaHandler : IRequestHandler<EstadoCuentaQuery, ResultData>
    {
        private readonly IReporteQuery reporteQuery;

        public EstadoCuentaHandler(IReporteQuery reporteQuery)
        {
            this.reporteQuery = reporteQuery;
        }

        public async Task<ResultData> Handle(EstadoCuentaQuery request, CancellationToken cancellationToken)
        {
            var estadosCuentas = await reporteQuery.EstadoCuenta(request.IdCliente, request.FechaInicio, request.FechaFinal);
            return new ResultData(HttpStatusCode.OK, "¡Reporte generado exitosamente!", estadosCuentas);
        }
    }
}
