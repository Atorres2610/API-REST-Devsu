using MediatR;

namespace Devsu.Core.Features.Cliente.Queries.ObtenerCliente
{
    public record ObtenerClienteQuery(int IdCliente) : IRequest<ObtenerClienteResponse>;
}
