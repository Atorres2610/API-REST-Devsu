using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Features.Cuenta.Commands.GuardarCuenta;
using Devsu.Core.MappingProfiles;
using Moq;
using System.Net;

namespace Devsu.Test.FunctionalTests.Cuenta
{
    public class GuardarCuentaTest
    {
        private readonly IMapper _mapper;

        public GuardarCuentaTest()
        {
            var myProfile = new CuentaMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }

        [Fact]
        public async void GuardarCuentaCorrecto()
        {
            Core.Entities.Cliente cliente = new()
            {
                IdCliente = 1
            };

            GuardarCuentaCommand command = new()
            {
                Numero = "12345",
                IdCliente = 1
            };

            var cuentaRepository = new Mock<ICuentaRepository>();
            var clienteRepository = new Mock<IClienteRepository>();
            _ = clienteRepository.Setup(c => c.ValidarExistencia(x => x.IdCliente == command.IdCliente)).Returns(() => Task.FromResult(true));

            GuardarCuentaHandler handler = new(cuentaRepository.Object, clienteRepository.Object, _mapper);
            Core.Models.Result result = await handler.Handle(command, new CancellationToken());

            Assert.Equal(HttpStatusCode.Created, result.Code);
        }

        [Fact]
        public async void GuardarCuentaIncorrecto()
        {
            var cuentaRepository = new Mock<ICuentaRepository>();
            var clienteRepository = new Mock<IClienteRepository>();
            GuardarCuentaHandler handler = new(cuentaRepository.Object, clienteRepository.Object, _mapper);
            Core.Models.Result result = await handler.Handle(null, new CancellationToken());

            Assert.Equal(HttpStatusCode.BadRequest, result.Code);
        }

        [Fact]
        public async void GuardarCuentaClienteInexistente()
        {
            Core.Entities.Cliente cliente = new()
            {
                IdCliente = 1
            };

            GuardarCuentaCommand command = new()
            {
                Numero = "12345",
                IdCliente = 2
            };

            var cuentaRepository = new Mock<ICuentaRepository>();
            var clienteRepository = new Mock<IClienteRepository>();
            _ = clienteRepository.Setup(c => c.ValidarExistencia(x => x.IdCliente == command.IdCliente)).Returns(() => Task.FromResult(false));

            GuardarCuentaHandler handler = new(cuentaRepository.Object, clienteRepository.Object, _mapper);
            Core.Models.Result result = await handler.Handle(command, new CancellationToken());

            Assert.Equal(HttpStatusCode.BadRequest, result.Code);
        }
    }
}
