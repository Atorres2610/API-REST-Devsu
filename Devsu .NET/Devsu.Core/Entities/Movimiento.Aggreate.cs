using Devsu.Util.Helpers;

namespace Devsu.Core.Entities
{
    public partial class Movimiento
    {
        public const decimal LIMITE_DIARIO = 1000;

        public enum Tipos
        {
            Credito,
            Debito
        }

        public void Actualizar()
        {
            Fecha = DateTimeHelper.PeruDateTime;
        }

        public string Transaccion(Tipos tipo, decimal saldo, decimal valorTransaccion, decimal limite)
        {
            Saldo = saldo;
            Fecha = DateTimeHelper.PeruDateTime;
            Limite = limite;

            switch (tipo)
            {
                case Tipos.Credito: Saldo += valorTransaccion; break;
                case Tipos.Debito:
                    if (Saldo < valorTransaccion || Saldo == 0)
                    {
                        return "Saldo no disponible.";
                    }

                    if (Limite == 0)
                    {
                        return "Cupo diario Excedido.";
                    }

                    if (valorTransaccion > limite)
                    {
                        return $"No se puede realizar la transacción, tu valor limite diario es de: ${limite}.";
                    }

                    Saldo -= valorTransaccion;
                    Limite -= valorTransaccion;
                    break;
            }
            return string.Empty;
        }

        public void Eliminar()
        {
            Eliminado = true;
        }
    }
}
