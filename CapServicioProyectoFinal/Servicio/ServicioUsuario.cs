using CapDominio.Entity;
using CapDominio.InterfaceRepository;
using CAPdominioProyectofinal.InterfaceServicio;
namespace CapAplicacion.Servicio
{
    public class ServicioUsuario : IUsuarioServicio
    {
        private readonly IUsuarioRepositoryGenery usuarioRepository;

        public ServicioUsuario(IUsuarioRepositoryGenery usuario)
        {
            usuarioRepository = usuario;
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            usuarioRepository.Update(usuario);
            
        }

        public async Task AddTestAsync(Usuario test)
        {
              await usuarioRepository.Add(test);
        }

        public Usuario Autenticar(string correo, string contrasena)
        {
            var usuarios = usuarioRepository.GetAll().Result;
            var usuario = usuarios.FirstOrDefault(u => u.Correo == correo);
            var verify = BCrypt.Net.BCrypt.Verify(contrasena, usuario.Contrasena);
            if (usuario != null && verify)
            {
                return usuario;
            }
            return null;
        }

        public Task DeleteTestAsync(int id)
        {
            return usuarioRepository.Delete(id);
        }

        public Task<IEnumerable<Usuario>> GetAllTestsAsync()
        {
            return usuarioRepository.GetAll();
        }

        public Task<Usuario> GetTestByIdAsync(int id)
        {
            return usuarioRepository.GetById(id);
        }

        public IEnumerable<Usuario> ObtecnerPorRol(Rol rol)
        {
            return usuarioRepository.GetAll().Result.Where(u => u.Rol == u.Rol);
        }

        public Usuario Obtenerporcorreo(string correo)
        {
            return usuarioRepository.GetAll().Result.FirstOrDefault(u => u.Correo == correo);
        }

        public Task UpdateTestAsync(Usuario test)
        {
            return usuarioRepository.Update(test);
        }
    }
}
