using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapDominio.InterfaceFactory
{
    public interface InterfaceGenery
    {
        T CrearServicio<T>() where  T : class ;
    }
}
