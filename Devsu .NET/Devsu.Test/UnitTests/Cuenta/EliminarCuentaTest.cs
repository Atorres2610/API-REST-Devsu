namespace Devsu.Test.UnitTests.Cuenta
{
    public class EliminarCuentaTest
    {
        [Fact]
        public void EliminarCuentaCorrecto()
        {
            Core.Entities.Cuenta cuenta = new()
            {
                Movimiento = new List<Core.Entities.Movimiento>()
            };

            cuenta.ELiminar();

            Assert.True(cuenta.Eliminado);
        }
    }
}