using CapDominio.InterfaceStrategy;
using CAPdominioProyectofinal.InterfaceServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
