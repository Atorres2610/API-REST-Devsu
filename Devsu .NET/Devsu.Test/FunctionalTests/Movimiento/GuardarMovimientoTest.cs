using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Features.Movimiento.Commands.GuardarMovimiento;
using Devsu.Core.MappingProfiles;
using Moq;
using System.Net;

namespace Devsu.Test.FunctionalTests.Movimiento
{
    public class GuardarMovimientoTest
    {
        private readonly IMapper _mapper;

        public GuardarMovimientoTest()
        {
            var myProfile = new MovimientoMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }

        [Fact]
        public async void GuardarMovimientoCorrecto()
        {
            Core.Entities.Cuenta cuenta = new()
            {
                IdCuenta = 1
            };

            GuardarMovimientoCommand command = new()
            {
                IdCuenta = 1,
                Tipo = Core.Entities.Movimiento.Tipos.Credito,
                Valor = 500
            };

            var cuentaRepository = new Mock<ICuentaRepository>();
            _ = cuentaRepository.Setup(c => c.Obtener(x => x.IdCuenta == command.IdCuenta, null, true)).Returns(() => Task.FromResult<Core.Entities.Cuenta?>(cuenta));

            var movimientoRepository = new Mock<IMovimientoRepository>();
            _ = movimientoRepository.Setup(c => c.ObtenerUltimoMovimientoPorIdCuenta(command.IdCuenta)).Returns(
                () => Task.FromResult<Core.Entities.Movimiento?>(null));

            GuardarMovimientoHandler handler = new(movimientoRepository.Object, cuentaRepository.Object, _mapper);
            Core.Models.Result result = await handler.Handle(command, new CancellationToken());

            Assert.Equal(HttpStatusCode.Created, result.Code);
        }

        [Fact]
        public async void GuardarMovimientoIncorrecto()
        {
            var cuentaRepository = new Mock<ICuentaRepository>();
            var movimientoRepository = new Mock<IMovimientoRepository>();

            GuardarMovimientoHandler handler = new(movimientoRepository.Object, cuentaRepository.Object, _mapper);
            Core.Models.Result result = await handler.Handle(null, new CancellationToken());

            Assert.Equal(HttpStatusCode.BadRequest, result.Code);
        }

        [Fact]
        public async void GuardarMovimientoCuentaInexistente()
        {
            GuardarMovimientoCommand command = new()
            {
                IdCuenta = 2,
                Tipo = Core.Entities.Movimiento.Tipos.Credito,
                Valor = 500
            };

            var cuentaRepository = new Mock<ICuentaRepository>();
            _ = cuentaRepository.Setup(c => c.Obtener(x => x.IdCuenta == command.IdCuenta, null, true)).Returns(() => Task.FromResult<Core.Entities.Cuenta?>(null));

            var movimientoRepository = new Mock<IMovimientoRepository>();
            _ = movimientoRepository.Setup(c => c.ObtenerUltimoMovimientoPorIdCuenta(command.IdCuenta)).Returns(
                () => Task.FromResult<Core.Entities.Movimiento?>(null));

            GuardarMovimientoHandler handler = new(movimientoRepository.Object, cuentaRepository.Object, _mapper);
            Core.Models.Result result = await handler.Handle(command, new CancellationToken());

            Assert.Equal(HttpStatusCode.BadRequest, result.Code);
        }
    }
}
