using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapDominio.Entity;
using CAPdominioProyectofinal.InterfaceRepository;
using CapInfraestructura.Context;


namespace CapInfraestructura.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContextoDB contextoDB;

        public UsuarioRepository(ContextoDB contexto)
        {
            contextoDB = contexto;
        }


        public void Add(Usuario usuario)
        {
           contextoDB.Usuarios.Add(usuario);
            contextoDB.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var usuario = contextoDB.Usuarios.Find(id);
            if (usuario == null)
            {
                contextoDB.Usuarios.Remove(usuario);
                contextoDB.SaveChanges();
            }

        }

        public IEnumerable<Usuario> GetAll()
        {
          return contextoDB.Usuarios.ToList();
            
        }

        public Usuario GetById(int id)
        {
            return contextoDB.Usuarios.Find(id);
        }

        public void GetById(string correo)
        {
           contextoDB.Usuarios.FirstOrDefault(u => u.Correo == correo);
        }

        public void Update(Usuario usuario)
        {
            var user = contextoDB.Usuarios.Find(usuario.IdUsuario);
            if (user != null)
            {
                user.Nombre = usuario.Nombre;
                user.Correo = usuario.Correo;
                user.Contrasena = usuario.Contrasena;
                user.Rol = usuario.Rol;
                user.FechaRegistro = usuario.FechaRegistro;
                contextoDB.SaveChanges();
            }
        }
    }
}
