using CapDominio.Entity;
using CapDominio.InterfaceServicio;
using CAPdominioProyectofinal.InterfaceServicio;
using Microsoft.AspNetCore.Mvc;
namespace Api_ProyectFinalAshlee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IPreguntasServicio _preguntaServicio;
        public TestController(ITestService testService, IPreguntasServicio preguntaServicio)
        {
            _testService = testService;
            _preguntaServicio = preguntaServicio;
        }
        [HttpGet]
        public async Task<IEnumerable<Encuesta>> Get()
        {
            var encuestas = await _testService.GetAllTestsAsync();
            return encuestas;
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost("crear")]
        public async Task<IActionResult> CrearEncuesta([FromBody] DToEncuestas dto)
        {
            var encuesta = new Encuesta
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                EsPublica = dto.EsPublica,
                FechaExpiracion = dto.FechaExpiracion,
                FechaCreacion = DateTime.Now,
                UsuarioId = dto.UsuarioId,
            };


            await _testService.AddAndReturnIdAsync(encuesta);


            var Preguntas = dto.Preguntas.Select(p => new Preguntas
            {
                Texto = p.Texto,
                TipoPregunta = p.TipoPregunta,
                EscalaMin = p.EscalaMin,
                EscalaMax = p.EscalaMax,
                EncuestaId = encuesta.Id,
                UsuarioId = dto.UsuarioId,
            }).ToList();

            foreach (var pregunta in Preguntas)
            {
                await _preguntaServicio.AddTestAsync(pregunta);
                var opciones = new Opciones
                {
                    Texto = pregunta.Texto,
                    PreguntaId = pregunta.Id,
                    EncuestaId = encuesta.Id
                };

                //Crea la interface de crear opciones y listo
            }


            return Ok("Encuesta creada correctamente");
        }


        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            var encuesta = await _testService.GetTestByIdAsync(id);
            if (encuesta != null)
            {
                _testService.UpdateTestAsync(encuesta);
            }
            else
            {
                throw new Exception("Encuesta no encontrada");
            }
            return Ok(encuesta);
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var encuesta = _testService.GetTestByIdAsync(id);
            if (encuesta != null)
            {
                _testService.DeleteTestAsync(id);
            }
            else
            {
                throw new Exception("Encuesta no encontrada");
            }
        }
    }
}
