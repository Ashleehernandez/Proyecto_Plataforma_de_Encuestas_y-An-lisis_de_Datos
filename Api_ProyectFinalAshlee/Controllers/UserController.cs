using CAPdominioProyectofinal.InterfaceServicio;
using CapDominio.Entity;
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
        public async Task<IActionResult> Registrar([FromBody] Usuario usuario)
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

             await  usuarioServicio.AddTestAsync(usuario);
            return CreatedAtAction(nameof(ObtenerUsuario), new { id = usuario.IdUsuario }, usuario);
        }



        // obtener usuario por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObtenerUsuario(int id)
        {
            var usuario = await usuarioServicio.GetTestByIdAsync(id);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            return Ok(usuario);
        }



        // Obtener todos los usuarios
        [HttpGet("todos")]
        public async Task<ActionResult<List<Usuario>>> ObtenerTodos()
        {
            var usuarios = await usuarioServicio.GetAllTestsAsync();
            return Ok(usuarios);
        }



        // actualizar usuario
        [HttpPut("{id}")]

        public async Task< IActionResult > ActualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || id != usuario.IdUsuario)
            {
                return BadRequest("Datos de usuario inválidos.");
            }

            
            var usuarioExistente = usuarioServicio.GetTestByIdAsync(id);
            if (usuarioExistente == null)
            {
                return Ok($"No se encontró un usuario con ID {id}.");
            }

            if (!string.IsNullOrEmpty(usuario.Contrasena))
            {
                usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
            }

            
           await usuarioServicio.UpdateTestAsync(usuario);

            return Ok(new { mensaje = "Usuario actualizado correctamente", usuario });

        }

        // eliminar usuario
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
           await usuarioServicio.DeleteTestAsync(id);
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
