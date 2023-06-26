using Devsu.Core.Models;
using MediatR;

namespace Devsu.Core.Features.Reporte.Queries
{
    public record EstadoCuentaQuery(int IdCliente, DateTime? FechaInicio, DateTime? FechaFinal) : IRequest<ResultData>;
}
