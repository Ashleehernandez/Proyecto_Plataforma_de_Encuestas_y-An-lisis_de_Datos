using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapAplicacion.Satrategy;
using CapDominio.InterfaceFactory;
using CAPdominioProyectofinal.InterfaceServicio;


namespace CapAplicacion.Factory
{
    public class ManejoFabricaObjectos 
    {
        private readonly ManejoStrategy manejoStrateg;

        public ManejoFabricaObjectos(ManejoStrategy manejoStrategy)
        {
            manejoStrateg = manejoStrategy;
        }
        public void UsarServicio()
        {
            var UsuarioService = manejoStrateg.ObtecnerServiciousuario();
            var CuentataService = manejoStrateg.ObtecnerServicioCuenta();
            var RespuestaService = manejoStrateg.ObtecnerServicioRespuesta();
            var PreguntaService = manejoStrateg.ObtecnerServicioPregunta();
        }

    }
}
