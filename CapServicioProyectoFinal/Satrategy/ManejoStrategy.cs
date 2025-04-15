using CAPdominioProyectofinal.InterfaceServicio;
using CapAplicacion.ServicioStrategy;
using CapDominio.InterfaceServicio;

namespace CapAplicacion.Satrategy
{
    public class ManejoStrategy 
    {

        private readonly ServicioCuentaStrategy servicioCuentaStrategy;
        private readonly ServicioPreguntaStrategy servicioPreguntasStrategy;
        private readonly ServicioUsuarioStrategy servicioUsuarioStrategy;
        private readonly ServicioRespuestaStrategy servicioRespuestaStrategy;

        public ManejoStrategy(ServicioRespuestaStrategy servicioRespuestaStrate, ServicioPreguntaStrategy servicioPreguntaStrate , ServicioCuentaStrategy servicioCuentaStrate, ServicioUsuarioStrategy servicioUsuarioStrate)
        {
            servicioUsuarioStrategy = servicioUsuarioStrate;
            servicioCuentaStrategy = servicioCuentaStrate;
            servicioPreguntasStrategy = servicioPreguntaStrate;
            servicioRespuestaStrategy = servicioRespuestaStrate;
        }

        public IUsuarioServicio ObtecnerServiciousuario()
        {
            return servicioUsuarioStrategy.ObtecnerServicio();
        }
        public ITestService ObtecnerServicioCuenta()
        {
            return servicioCuentaStrategy.ObtecnerServicio();
        }
        public IPreguntasServicio ObtecnerServicioPregunta()
        {
            return servicioPreguntasStrategy.ObtecnerServicio();
        }
        public IPreguntasServicio ObtecnerServicioRespuesta()
        {
            return servicioRespuestaStrategy.ObtecnerServicio();
        }
    }
}
