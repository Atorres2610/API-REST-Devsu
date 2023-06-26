namespace Devsu.Core.Entities
{
    public partial class Cuenta
    {
        public enum Tipos
        {
            Ahorros,
            Corriente
        }

        internal void ELiminar()
        {
            Eliminado = true;
            foreach (var movimiento in Movimiento)
            {
                movimiento.Eliminado = true;
            }
        }
    }
}
