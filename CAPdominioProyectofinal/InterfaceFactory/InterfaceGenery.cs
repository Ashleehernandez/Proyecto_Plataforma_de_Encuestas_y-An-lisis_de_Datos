
namespace CapDominio.InterfaceFactory
{
    public interface InterfaceGenery
    {
        T CrearServicio<T>() where  T : class ;
    }
}
