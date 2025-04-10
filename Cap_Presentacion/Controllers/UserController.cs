using CapAplicacion.Servicio;
using CapDominio.Entity;
using CAPdominioProyectofinal.InterfaceServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cap_Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioServicio servicioUsuario;

        public UserController(IUsuarioServicio servicio)
        {
            servicioUsuario = servicio;
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

            servicioUsuario.CrearUsuario(usuario);
            return CreatedAtAction(nameof(servicioUsuario.ObtecnerUserId), new { id = usuario.IdUsuario }, usuario);
        }

        // obtener usuario por id
        [HttpGet("{id}")]
        public IActionResult ObtenerUsuario(int id)
        {
            var usuario = servicioUsuario.ObtecnerUserId(id);

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
            var usuarios = servicioUsuario.ObtecnerTodo();
            return Ok(usuarios);
        }
        // actualizar usuario
        [HttpPut("{id}")]

        public IActionResult ActualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest("Datos de usuario inválidos.");
            }
            return Ok(usuario);

        }
        // eliminar usuario
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            servicioUsuario.EliminarUsuario(id);
            return Ok("Usuario Eliminado");
        }



        [HttpPost("Rol/{rol}")]
        public IActionResult ObtenerPorRol(string rol)
        {
            if (!Enum.TryParse<Rol>(rol, true, out _))
            {
                return BadRequest("Rol inválido.");
            }
            var usuarios = servicioUsuario.ObtecnerPorRol((Rol)Enum.Parse(typeof(Rol), rol, true));
            return Ok(usuarios);
        }
    }
}
