using CAPdominioProyectofinal.InterfaceServicio;
using CapDominio.InterfaceStrategy;
using CapDominio.InterfaceServicio;


namespace CapAplicacion.ServicioStrategy
{
    public class ServicioCuentaStrategy : InterfaceStrategyGenery<ITestService>
    {
        private readonly ITestService _cuentaServicio;

        public ServicioCuentaStrategy(ITestService cuenta)
        {
            _cuentaServicio = cuenta;

        }

        public ITestService ObtecnerServicio()
        {
           return _cuentaServicio;
        }
    }
}
