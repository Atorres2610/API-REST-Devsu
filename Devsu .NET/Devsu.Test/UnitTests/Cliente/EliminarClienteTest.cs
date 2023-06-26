namespace Devsu.Test.UnitTests.Cliente
{
    public class EliminarClienteTest
    {
        [Fact]
        public void EliminarClienteCorrecto()
        {
            Core.Entities.Cliente cliente = new()
            {
                IdPersonaNavigation = new Core.Entities.Persona()
            };
            cliente.Eliminar();

            Assert.True(cliente.Eliminado);
        }
    }
}
