using CAPdominioProyectofinal.InterfaceServicio;
using CapDominio.InterfaceStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapAplicacion.ServicioStrategy
{
    public class ServicioPreguntaStrategy : InterfaceStrategyGenery<IPreguntasServicio>
    {
        private readonly IPreguntasServicio _preguntasServicio;

        public ServicioPreguntaStrategy(IPreguntasServicio preguntasServicio)
        {
            _preguntasServicio = preguntasServicio;

        }

        public IPreguntasServicio ObtecnerServicio()
        {
            return _preguntasServicio;
        }
    }
}
