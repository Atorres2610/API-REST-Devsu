using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Devsu.Core.Features.Cuenta.Queries.ListarCuenta
{
    public class ListarCuentaHandler : IRequestHandler<ListarCuentaQuery, Result>
    {
        private readonly ICuentaRepository cuentaRepository;

        public ListarCuentaHandler(ICuentaRepository cuentaRepository)
        {
            this.cuentaRepository = cuentaRepository;
        }

        public async Task<Result> Handle(ListarCuentaQuery request, CancellationToken cancellationToken)
        {
            var listaCuentas = await cuentaRepository.Listar();
            ListarCuentaResponse response = new(listaCuentas);
            return new Result(StatusCodes.Status200OK, response);
        }
    }
}
