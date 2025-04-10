using Microsoft.AspNetCore.Http;
using CapAplicacion.Servicio;
using Microsoft.AspNetCore.Mvc;
using CapDominio.Entity;

namespace Cap_Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ServicioUsuario usuarioServicio;
        public LoginController(ServicioUsuario usuario)
        {
            usuarioServicio = usuario;
        }
        [HttpPost]
        public IActionResult Autenticar([FromBody] Usuario usuario)
        {
            var usuarioAutenticado = usuarioServicio.Autenticar(usuario.Correo, usuario.Contrasena);
            if (usuarioAutenticado != null)
            {
                return Ok(usuarioAutenticado);
            }
            return Unauthorized();
        }

    }
}
