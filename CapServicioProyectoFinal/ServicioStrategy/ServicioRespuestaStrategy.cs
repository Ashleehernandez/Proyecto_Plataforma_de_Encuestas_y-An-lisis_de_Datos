using CAPdominioProyectofinal.InterfaceServicio;
using CapDominio.InterfaceStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapAplicacion.ServicioStrategy
{
    public class ServicioRespuestaStrategy : InterfaceStrategyGenery<IPreguntasServicio>
    {
        private readonly IPreguntasServicio _preguntasServicio;

        public ServicioRespuestaStrategy(IPreguntasServicio preguntas)
        {
            _preguntasServicio = preguntas;
        }

        public IPreguntasServicio ObtecnerServicio()
        {
            return _preguntasServicio;
        }
    }
}
