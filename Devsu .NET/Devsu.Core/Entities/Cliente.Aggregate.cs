namespace Devsu.Core.Entities
{
    public partial class Cliente
    {
        internal void Eliminar()
        {
            Eliminado = true;
            IdPersonaNavigation.Eliminado = true;
            foreach (var cuenta in Cuenta)
            {
                cuenta.Eliminado = true;
                foreach (var movimiento in cuenta.Movimiento)
                {
                    movimiento.Eliminado = true;
                }
            }
        }
    }
}
