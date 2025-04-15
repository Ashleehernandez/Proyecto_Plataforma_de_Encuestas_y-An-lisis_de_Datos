using CapDominio.InterfaceFactory;
namespace CapAplicacion.Factory
{
    public class ServicioFactory : InterfaceGenery
    {
        private readonly IServiceProvider _serviceProvider;

        public ServicioFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T CrearServicio<T>() where T : class
        {
            return _serviceProvider.GetService(typeof(T)) as T;
        }
    }
}
