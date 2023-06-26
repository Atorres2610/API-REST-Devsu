using AutoMapper;
using Devsu.Core.Contracts.Repositories;
using Devsu.Core.Features.Cliente.Commands.GuardarCliente;
using Devsu.Core.MappingProfiles;
using Moq;
using System.Net;

namespace Devsu.Test.FunctionalTests.Cliente
{
    public class GuardarClienteTest
    {
        private readonly IMapper _mapper;

        public GuardarClienteTest()
        {
            var myProfile = new ClienteMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }

        [Fact]
        public async void GuardarClienteCorrecto()
        {
            var clienteRepository = new Mock<IClienteRepository>();

            GuardarClienteCommand command = new()
            {
                Contrasena = "12345",
                Direccion = "Avenida 123",
                Genero = "Masculino",
                Identificacion = "12345",
                Nombres = "Nombre1 Apellido2",
                Telefono = "12345",
                Edad = 20,
                Estado = true,
            };

            GuardarClienteHandler handler = new(clienteRepository.Object, _mapper);
            Core.Models.Result result = await handler.Handle(command, new CancellationToken());

            Assert.Equal(HttpStatusCode.Created, result.Code);
        }

        [Fact]
        public async void GuardarClienteIncorrecto()
        {
            var clienteRepository = new Mock<IClienteRepository>();
            GuardarClienteHandler handler = new(clienteRepository.Object, _mapper);
            Core.Models.Result result = await handler.Handle(null, new CancellationToken());

            Assert.Equal(HttpStatusCode.BadRequest, result.Code);
        }
    }
}
