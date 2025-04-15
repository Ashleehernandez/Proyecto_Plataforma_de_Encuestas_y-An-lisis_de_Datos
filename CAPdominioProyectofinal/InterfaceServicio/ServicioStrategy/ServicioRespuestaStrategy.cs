using CAPdominioProyectofinal.InterfaceServicio;
using CapDominio.InterfaceStrategy;


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
