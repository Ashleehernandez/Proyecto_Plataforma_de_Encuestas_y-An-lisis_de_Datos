using CapDominio.InterfaceStrategy;
using CAPdominioProyectofinal.InterfaceServicio;


namespace CapAplicacion.ServicioStrategy
{
    public class ServicioUsuarioStrategy : InterfaceStrategyGenery<IUsuarioServicio>
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public ServicioUsuarioStrategy( IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;  
        }



        public IUsuarioServicio ObtecnerServicio()
        {
            return _usuarioServicio;
        }
    }
}
