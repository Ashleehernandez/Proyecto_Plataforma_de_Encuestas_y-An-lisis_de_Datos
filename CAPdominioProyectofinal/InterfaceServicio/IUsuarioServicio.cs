using CapDominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPdominioProyectofinal.InterfaceServicio
{
    public interface IUsuarioServicio
    {
        Usuario ObtecnerUserId(int id);
        IEnumerable<Usuario> ObtecnerTodo();
        Usuario CrearUsuario(Usuario usuario);
        void ActualizarUsuario(Usuario usuario);
        void EliminarUsuario(int id);


        Usuario Obtenerporcorreo(string correo);
        Usuario Autenticar(string correo, string contrasena);
        IEnumerable<Usuario> ObtecnerPorRol(Rol rol);

    }
}
