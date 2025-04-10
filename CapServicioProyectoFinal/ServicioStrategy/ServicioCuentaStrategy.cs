using CAPdominioProyectofinal.InterfaceServicio;
using CapDominio.InterfaceStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapAplicacion.ServicioStrategy
{
    public class ServicioCuentaStrategy : InterfaceStrategyGenery<IEncuestaServicio>
    {
        private readonly IEncuestaServicio _cuentaServicio;

        public ServicioCuentaStrategy(IEncuestaServicio cuenta)
        {
            _cuentaServicio = cuenta;

        }

        public IEncuestaServicio ObtecnerServicio()
        {
            return _cuentaServicio; 
        }
    }
}
