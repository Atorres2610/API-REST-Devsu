using Devsu.Core.Models;
using MediatR;

namespace Devsu.Core.Features.Cliente.Queries.ListarCliente
{
    public record ListarClienteQuery() : IRequest<Result>;
}
