using Microsoft.AspNetCore.Http;
using CapAplicacion.Servicio;
using CapDominio.Entity;
using Microsoft.AspNetCore.Mvc;
using CAPdominioProyectofinal.InterfaceServicio;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api_ProyectFinalAshlee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioServicio usuarioServicio;

        public LoginController(IUsuarioServicio usuario)
        {
            usuarioServicio = usuario;
        }

        [HttpPost]
        public IActionResult Autenticar([FromBody] LoginRequest login)
        {
            if (login == null || string.IsNullOrEmpty(login.Correo) || string.IsNullOrEmpty(login.Contrasena))
            {
                return BadRequest("El cuerpo de la solicitud está vacío o incompleto.");
            }
            var usuarioAutenticado = usuarioServicio.Autenticar(login.Correo, login.Contrasena);
            if (usuarioAutenticado != null)
            {
                // Genera el token JWT
                var token = GenerarToken(usuarioAutenticado);
                return Ok(new { Usuario = usuarioAutenticado, Token = token });
            }
            return Unauthorized();
        }

        private string GenerarToken(Usuario usuario)
        {
            // Define los "claims" (información incluida en el token)
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, usuario.IdUsuario.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Correo),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

            // Define la clave secreta
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("claveSecretaMuyLargaYSegura12345"));

            // Define las credenciales de firma
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Crea el token
            var token = new JwtSecurityToken(
                issuer: "http://localhost:1347",
                audience: "http://localhost:1347",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
