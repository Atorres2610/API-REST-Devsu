namespace Devsu.Test.UnitTests.Movimiento
{
    public class ValidarTransaccionTest
    {
        [Fact]
        public void ValidarTransaccionCreditoCorrecto()
        {
            Core.Entities.Movimiento movimiento = new()
            {
                Limite = Core.Entities.Movimiento.LIMITE_DIARIO,
                Valor = 1500,
                Tipo = Core.Entities.Movimiento.Tipos.Credito.ToString(),
                Saldo = 2000,
            };

            string respuestaValidacion = movimiento.Transaccion(
                Core.Entities.Movimiento.Tipos.Credito, movimiento.Saldo, movimiento.Valor, movimiento.Limite);

            Assert.Empty(respuestaValidacion);
        }

        [Fact]
        public void ValidarTransaccionDebitoCorrecto()
        {
            Core.Entities.Movimiento movimiento = new()
            {
                Limite = Core.Entities.Movimiento.LIMITE_DIARIO,
                Valor = 500,
                Tipo = Core.Entities.Movimiento.Tipos.Debito.ToString(),
                Saldo = 2000,
            };

            string respuestaValidacion = movimiento.Transaccion(
                Core.Entities.Movimiento.Tipos.Debito, movimiento.Saldo, movimiento.Valor, movimiento.Limite);

            Assert.Empty(respuestaValidacion);
        }

        [Fact]
        public void ValidarTransaccionDebitoIncorrecto()
        {
            Core.Entities.Movimiento movimiento = new()
            {
                Limite = Core.Entities.Movimiento.LIMITE_DIARIO,
                Valor = 2500,
                Tipo = Core.Entities.Movimiento.Tipos.Debito.ToString(),
                Saldo = 2000,
            };

            string respuestaValidacion = movimiento.Transaccion(
                Core.Entities.Movimiento.Tipos.Debito, movimiento.Saldo, movimiento.Valor, movimiento.Limite);

            Assert.NotEmpty(respuestaValidacion);
        }
    }
}
