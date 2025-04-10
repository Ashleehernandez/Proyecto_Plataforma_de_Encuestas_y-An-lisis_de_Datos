using CAPdominioProyectofinal.InterfaceServicio;
using CapAplicacion.Servicio;
using CapDominio.Entity;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace Api_ProyectFinalAshlee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioServicio usuarioServicio;

        public UserController(IUsuarioServicio usuario)
        {
            usuarioServicio = usuario;

        }

        // registrar usuario
        [HttpPost("registrar")]
        public IActionResult Registrar([FromBody] Usuario usuario)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.Correo) || string.IsNullOrEmpty(usuario.Contrasena) || string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrEmpty(usuario.Rol))
            {
                return BadRequest("Datos de usuario inválidos.");
            }

            // Validar el rol.
            if (!Enum.TryParse<Rol>(usuario.Rol, true, out _))
            {
                return BadRequest("Rol inválido.");
            }

            // Encriptar la contraseña antes de guardarla.
            usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);

            usuarioServicio.CrearUsuario(usuario);
            return CreatedAtAction(nameof(ObtenerUsuario), new { id = usuario.IdUsuario }, usuario);
        }

        // obtener usuario por id
        [HttpGet("{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            var usuario = usuarioServicio.ObtecnerUserId(id);

            if (usuario == null)
            {
                return Ok("Usuario no Encontrado ");
            }

            return Ok(usuario);
        }
        // obtener todos los usuarios
        [HttpGet("todos")]

        public IActionResult ObtenerTodos()
        {
            var usuarios = usuarioServicio.ObtecnerTodo();
            return Ok(usuarios);
        }

        // actualizar usuario
        [HttpPut("{id}")]

        public IActionResult ActualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || id != usuario.IdUsuario)
            {
                return BadRequest("Datos de usuario inválidos.");
            }

            
            var usuarioExistente = usuarioServicio.ObtecnerUserId(id);
            if (usuarioExistente == null)
            {
                return Ok($"No se encontró un usuario con ID {id}.");
            }

            if (!string.IsNullOrEmpty(usuario.Contrasena))
            {
                usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
            }

            
            usuarioServicio.ActualizarUsuario(usuario);

            return Ok(new { mensaje = "Usuario actualizado correctamente", usuario });

        }
        // eliminar usuario
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            usuarioServicio.EliminarUsuario(id);
            return Ok("Usuario Eliminado");
        }



        [HttpPost("Rol/{rol}")]
        public IActionResult ObtenerPorRol(string rol)
        {
            if (!Enum.TryParse<Rol>(rol, true, out _))
            {
                return BadRequest("Rol inválido.");
            }
            var usuarios = usuarioServicio.ObtecnerPorRol((Rol)Enum.Parse(typeof(Rol), rol, true));
            return Ok(usuarios);
        }

    }
}
