using Devsu.Core.Models;
using MediatR;

namespace Devsu.Core.Features.Cliente.Commands.EliminarCliente
{
    public record EliminarClienteCommand(int IdCliente) : IRequest<Result>;
}