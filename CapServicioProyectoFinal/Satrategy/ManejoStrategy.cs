using CAPdominioProyectofinal.InterfaceServicio;
using CapDominio.InterfaceStrategy;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapAplicacion.ServicioStrategy;

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
        public IEncuestaServicio ObtecnerServicioCuenta()
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
