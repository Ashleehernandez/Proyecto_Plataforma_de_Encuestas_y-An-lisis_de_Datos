using CAPdominioProyectofinal.InterfaceServicio;
using CapDominio.InterfaceStrategy;


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
