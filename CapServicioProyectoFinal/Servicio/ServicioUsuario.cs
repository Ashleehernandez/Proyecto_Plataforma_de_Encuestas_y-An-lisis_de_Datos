using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapDominio.Entity;
using CAPdominioProyectofinal.InterfaceRepository;
using CAPdominioProyectofinal.InterfaceServicio;
using CapInfraestructura.Repository;
using Org.BouncyCastle.Crypto.Generators;



namespace CapAplicacion.Servicio
{
    public class ServicioUsuario : IUsuarioServicio
    {
        private readonly IUsuarioRepository usuarioRepository;

        public ServicioUsuario(IUsuarioRepository usuario)
        {
            usuarioRepository = usuario;
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            usuarioRepository.Update(usuario);
            
        }

        public Usuario Autenticar(string correo, string contrasena)
        {
            var usuario = usuarioRepository.GetAll().FirstOrDefault(u => u.Correo == correo);
            if (usuario != null && BCrypt.Net.BCrypt.Verify(contrasena, usuario.Contrasena))
            {
                return usuario;
            }
            return null;
        }

        public Usuario CrearUsuario(Usuario usuario)
        {
            usuarioRepository.Add(usuario);
            return usuario;
        }

        public void EliminarUsuario(int id)
        {
            usuarioRepository.Delete(id);
           
        }

        
        public IEnumerable<Usuario> ObtecnerPorRol(Rol rol)
        {
            return usuarioRepository.GetAll().Where(u => u.Rol == rol.ToString());
        }

      
        public IEnumerable<Usuario> ObtecnerTodo()
        {
           return usuarioRepository.GetAll();
            
        }

        public Usuario ObtecnerUserId(int id)
        {
           return usuarioRepository.GetById(id);
            
        }

        public Usuario Obtenerporcorreo(string correo)
        {
            return usuarioRepository.GetAll().FirstOrDefault(u => u.Correo == correo);
        }
    }
}
