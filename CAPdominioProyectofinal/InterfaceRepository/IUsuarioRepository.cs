using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapDominio.Entity;

namespace CAPdominioProyectofinal.InterfaceRepository
{
    public interface IUsuarioRepository
    {
         IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
       void Delete(int id);
        void GetById(string correo);
    }
}
