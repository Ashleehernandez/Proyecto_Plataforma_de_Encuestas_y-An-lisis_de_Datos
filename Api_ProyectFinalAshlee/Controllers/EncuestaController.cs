using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_ProyectFinalAshlee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly IEncuestaServicio _encuestaServicio;
        public EncuestaController(IEncuestaServicio encuestaServicio)
        {
            _encuestaServicio = encuestaServicio;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var encuestas = _encuestaServicio.ObtenerTodas();
                return Ok(encuestas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", details = ex.Message });
            }
        }

        // GET: api/encuestas/publicas
        [HttpGet("publicas")]
        [AllowAnonymous]
        public IActionResult GetPublicas()
        {
            try
            {
                var encuestas = _encuestaServicio.ObtenerPublicas();
                return Ok(encuestas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener encuestas públicas", details = ex.Message });
            }
        }

        // GET: api/encuestas/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var encuesta = _encuestaServicio.ObtenerPorId(id);
                if (encuesta == null)
                {
                    return NotFound(new { message = "Encuesta no encontrada" });
                }
                return Ok(encuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener la encuesta", details = ex.Message });
            }
        }

        // POST: api/encuestas
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Create([FromBody] Encuesta encuesta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var nuevaEncuesta = _encuestaServicio.Crear(encuesta);
                return CreatedAtAction(nameof(GetById), new { id = nuevaEncuesta.Id }, nuevaEncuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al crear la encuesta", details = ex.Message });
            }
        }

        // PUT: api/encuestas/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Update(int id, [FromBody] Encuesta encuesta)
        {
            try
            {
                if (id != encuesta.Id)
                {
                    return BadRequest(new { message = "ID de encuesta no coincide" });
                }

                _encuestaServicio.Actualizar(encuesta);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar la encuesta", details = ex.Message });
            }
        }

        // DELETE: api/encuestas/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            try
            {
                _encuestaServicio.Eliminar(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar la encuesta", details = ex.Message });
            }
        }

        // GET: api/encuestas/usuario/5
        [HttpGet("usuario/{usuarioId}")]
        public IActionResult GetByUsuario(int usuarioId)
        {
            try
            {
                var encuestas = _encuestaServicio.ObtenerPorUsuario(usuarioId);
                return Ok(encuestas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener encuestas del usuario", details = ex.Message });
            }
        }

        // PATCH: api/encuestas/5/estado
        [HttpPatch("{id}/estado")]
        [Authorize(Roles = "Administrador")]
        public IActionResult CambiarEstado(int id, [FromBody] EstadoEncuesta estado)
        {
            try
            {
                _encuestaServicio.CambiarEstado(id, estado);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al cambiar estado", details = ex.Message });
            }
        }
    }
}
    

