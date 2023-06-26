namespace Devsu.Core.Entities
{
    public partial class Cuenta
    {
        public enum Tipos
        {
            Ahorros,
            Corriente
        }

        public void ELiminar()
        {
            Eliminado = true;
            foreach (var movimiento in Movimiento)
            {
                movimiento.Eliminado = true;
            }
        }
    }
}
