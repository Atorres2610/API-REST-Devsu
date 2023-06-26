namespace Devsu.Test.UnitTests.Movimiento
{
    public class EliminarMovimientoTest
    {
        [Fact]
        public void EliminarMovimientoCorrecto()
        {
            Core.Entities.Movimiento movimiento = new();
            movimiento.Eliminar();

            Assert.True(movimiento.Eliminado);
        }
    }
}
