using CapAplicacion.Servicio;
using CapDominio.Entity;
using CAPdominioProyectofinal.InterfaceServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_ProyectFinalAshlee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestaController : ControllerBase
    {
        private readonly ServicioRespuestaAdapters _respuestaAdapter;
        private readonly IPreguntasServicio _preguntasServicio; // Inyectar IPreguntasServicio

        public RespuestaController(ServicioRespuestaAdapters respuestaAdapter, IPreguntasServicio preguntasServicio)
        {
            _respuestaAdapter = respuestaAdapter;
            _preguntasServicio = preguntasServicio;
        }

        [HttpPost]
        public async Task<ActionResult<Respuestas>> RegistrarRespuesta(RespuestaDto respuestaDto)
        {
            try
            {
                // 1. Validar la existencia de la pregunta
                var pregunta = _preguntasServicio.GetTestByIdAsync(respuestaDto.PreguntaId); // Remove await
                if (pregunta == null)
                {
                    return NotFound($"No se encontró la pregunta con ID {respuestaDto.PreguntaId}");
                }

                // 2. Crear la entidad Respuestas desde el DTO
                var respuesta = new Respuestas
                {
                    UsuarioId = respuestaDto.UsuarioId,
                    PreguntaId = respuestaDto.PreguntaId,
                    RespuestaTexto = respuestaDto.RespuestaTexto,
                    RespuestaSeleccionada = respuestaDto.RespuestaSeleccionada,
                    Puntaje = respuestaDto.Puntaje,
                    FechaRespuesta = DateTime.UtcNow // O usa la zona horaria adecuada
                };

                // 3. Usar el adaptador para crear la respuesta
                var nuevaRespuesta = await _respuestaAdapter.CrearRespuesta(respuesta);

                // 4. Retornar CreatedAtAction
                return CreatedAtAction(nameof(ObtenerRespuestaPorId), new { id = nuevaRespuesta.Id }, nuevaRespuesta);
            }
            catch (Exception ex)
            {
                // 5. Loggear el error para depuración
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al registrar la respuesta: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Respuestas>> ObtenerRespuestaPorId(int id)
        {
            try
            {
                var respuesta = await _respuestaAdapter.RespuestasPorId(id);
                if (respuesta == null)
                {
                    return NotFound($"No se encontró la respuesta con ID {id}");
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                // Loggear el error para depuración
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener la respuesta: {ex.Message}");
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Respuestas>>> ObtenerRespuestasPorUsuario(int usuarioId)
        {
            try
            {
                var respuestas = await _respuestaAdapter.ObtenerTodo(); // Corregido: Usar el método correcto del adaptador
                // Filtrar las respuestas por UsuarioId en la capa de servicio o en el controlador (si es simple)
                var respuestasUsuario = respuestas.Where(r => r.UsuarioId == usuarioId);
                return Ok(respuestasUsuario);
            }
            catch (Exception ex)
            {
                // Loggear el error para depuración
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener las respuestas del usuario: {ex.Message}");
            }
        }

        [HttpGet("pregunta/{preguntaId}")]
        public async Task<ActionResult<IEnumerable<Respuestas>>> ObtenerRespuestasPorPregunta(int preguntaId)
        {
            try
            {
                var respuestas = await _respuestaAdapter.ObtenerTodo(); // Corregido: Usar el método correcto del adaptador
                // Filtrar las respuestas por PreguntaId en la capa de servicio o en el controlador (si es simple)
                var respuestasPregunta = respuestas.Where(r => r.PreguntaId == preguntaId);
                return Ok(respuestasPregunta);
            }
            catch (Exception ex)
            {
                // Loggear el error para depuración
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener las respuestas de la pregunta: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarRespuesta(int id, RespuestaDto respuestaDto)
        {
            try
            {
                // 1. Validar el ID
                if (id != respuestaDto.Id)
                {
                    return BadRequest("El ID de la respuesta no coincide con el ID proporcionado.");
                }

                // 2. Obtener la respuesta existente
                var respuestaExistente = await _respuestaAdapter.RespuestasPorId(id);
                if (respuestaExistente == null)
                {
                    return NotFound($"No se encontró la respuesta con ID {id}");
                }

                // 3. Actualizar las propiedades
                respuestaExistente.UsuarioId = respuestaDto.UsuarioId;
                respuestaExistente.PreguntaId = respuestaDto.PreguntaId;
                respuestaExistente.RespuestaTexto = respuestaDto.RespuestaTexto;
                respuestaExistente.RespuestaSeleccionada = respuestaDto.RespuestaSeleccionada;
                respuestaExistente.Puntaje = respuestaDto.Puntaje;
                // La FechaRespuesta generalmente no se actualiza

                // 4. Usar el adaptador para actualizar
                var respuestaActualizada = await _respuestaAdapter.ActualizarRespuesta(respuestaExistente);

                // 5. Retornar NoContent
                return NoContent();
            }
            catch (Exception ex)
            {
                // Loggear el error para depuración
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar la respuesta: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRespuesta(int id)
        {
            try
            {
                // 1. Obtener la respuesta existente
                var respuestaExistente = await _respuestaAdapter.RespuestasPorId(id);
                if (respuestaExistente == null)
                {
                    return NotFound($"No se encontró la respuesta con ID {id}");
                }

                // 2. Usar el adaptador para eliminar
                await _respuestaAdapter.EliminarPreguntaId(id); // Usar el método correcto del adaptador

                // 3. Retornar NoContent
                return NoContent();
            }
            catch (Exception ex)
            {
                // Loggear el error para depuración
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la respuesta: {ex.Message}");
            }
        }
    }
}

