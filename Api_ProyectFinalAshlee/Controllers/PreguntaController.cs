using CapDominio.Entity;
using CAPdominioProyectofinal.InterfaceServicio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_ProyectFinalAshlee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaController : ControllerBase
    {
        private readonly IPreguntasServicio _preguntasServicio;

        public PreguntaController(IPreguntasServicio preguntas)
        {
            _preguntasServicio = preguntas;

        }

        // POST: api/Pregunta
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Create([FromBody] PreguntaDto preguntaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Convertir DTO a entidad Preguntas
                var pregunta = new Preguntas
                {
                    Texto = preguntaDto.Texto,
                    TipoPregunta = preguntaDto.TipoPregunta,
                    EncuestaId = preguntaDto.EncuestaId,
                    UsuarioId = preguntaDto.UsuarioId
                };

                // Configurar según el tipo de pregunta
                if (pregunta.TipoPregunta == TipoPregunta.OpcionMultiple)
                {
                    pregunta.Opciones = preguntaDto.Opciones?.Select(o => new Opcion { Texto = o }).ToList();
                    pregunta.EscalaMin = null;
                    pregunta.EscalaMax = null;
                }
                else if (pregunta.TipoPregunta == TipoPregunta.EscalaCalificacion)
                {
                    pregunta.EscalaMin = preguntaDto.EscalaMin ?? 1;
                    pregunta.EscalaMax = preguntaDto.EscalaMax ?? 5;
                    pregunta.Opciones = null;
                }

                var preguntaCreada = _preguntasServicio.CrearPregunta(pregunta);
                return CreatedAtAction(nameof(GetById), new { id = preguntaCreada.Id }, preguntaCreada);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al crear la pregunta", details = ex.Message });
            }
        }

        // GET: api/Pregunta/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var pregunta = _preguntasServicio.ObtenerPreguntaId(id);
                if (pregunta == null)
                {
                    return NotFound(new { message = "Pregunta no encontrada" });
                }
                return Ok(pregunta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al obtener la pregunta", details = ex.Message });
            }
        }

        // GET: api/Pregunta/encuesta/5
        [HttpGet("encuesta/{encuestaId}")]
        public IActionResult GetByEncuesta(int encuestaId)
        {
            try
            {
                var preguntas = _preguntasServicio.ObtenerPorEncuestaId(encuestaId);
                return Ok(preguntas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al obtener preguntas de la encuesta", details = ex.Message });
            }
        }

        // PUT: api/Pregunta/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Update(int id, [FromBody] PreguntaDto preguntaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var preguntaExistente = _preguntasServicio.ObtenerPreguntaId(id);
                if (preguntaExistente == null)
                {
                    return NotFound(new { message = "Pregunta no encontrada" });
                }

                // Actualizar propiedades básicas
                preguntaExistente.Texto = preguntaDto.Texto;
                preguntaExistente.TipoPregunta = preguntaDto.TipoPregunta;

                // Actualizar según tipo de pregunta
                if (preguntaDto.TipoPregunta == TipoPregunta.OpcionMultiple)
                {
                    preguntaExistente.Opciones = preguntaDto.Opciones?.Select(o => new Opcion { Texto = o }).ToList();
                    preguntaExistente.EscalaMin = null;
                    preguntaExistente.EscalaMax = null;
                }
                else if (preguntaDto.TipoPregunta == TipoPregunta.EscalaCalificacion)
                {
                    preguntaExistente.EscalaMin = preguntaDto.EscalaMin ?? 1;
                    preguntaExistente.EscalaMax = preguntaDto.EscalaMax ?? 5;
                    preguntaExistente.Opciones = null;
                }

                _preguntasServicio.ActualizarPregunta(preguntaExistente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al actualizar la pregunta", details = ex.Message });
            }
        }

        // DELETE: api/Pregunta/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            try
            {
                var pregunta = _preguntasServicio.ObtenerPreguntaId(id);
                if (pregunta == null)
                {
                    return NotFound(new { message = "Pregunta no encontrada" });
                }

                // Verificar si tiene respuestas antes de eliminar
                if (pregunta.Respuestas?.Count > 0)
                {
                    return BadRequest(new { message = "No se puede eliminar una pregunta con respuestas" });
                }

                _preguntasServicio.EliminarPregunta(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al eliminar la pregunta", details = ex.Message });
            }
        }

        // GET: api/Pregunta/tipo/{tipoPregunta}
        [HttpGet("tipo/{tipoPregunta}")]
        public IActionResult GetByType(TipoPregunta tipoPregunta)
        {
            try
            {
                var preguntas = _preguntasServicio.ObtenerPorTipoPregunta(tipoPregunta);
                return Ok(preguntas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al obtener preguntas por tipo", details = ex.Message });
            }
        }

        // GET: api/Pregunta
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var preguntas = _preguntasServicio.ObtenerTodo();
                return Ok(preguntas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al obtener todas las preguntas", details = ex.Message });
            }
        }
    }

}

