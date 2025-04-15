using CapDominio.Entity;
using CapDominio.InterfaceRepository;
using CAPdominioProyectofinal.InterfaceServicio;


namespace CapAplicacion.Servicio
{
    public class ServicioRespuesta : IPreguntasServicio
    {
        private readonly IRespuestaRepositoryGenery _respuestaRepo;

        public ServicioRespuesta(IRespuestaRepositoryGenery respuestaRepo)
        {
            _respuestaRepo = respuestaRepo;
        }

        public async Task AddTestAsync(Preguntas test)
        {
            var respuesta = MapearRespuesta(test);
            await _respuestaRepo.Add(respuesta);
        }

        public async Task DeleteTestAsync(int id)
        {
            var respuesta = MapearPregunta(await _respuestaRepo.GetById(id));
            await _respuestaRepo.Delete(id);
        }

        public async Task<IEnumerable<Preguntas>> GetAllTestsAsync()
        {
            var respuestas = await _respuestaRepo.GetAll();
            return respuestas.Select(MapearPregunta);
        }

        public async Task<Preguntas> GetTestByIdAsync(int id)
        {
            var respuesta = await _respuestaRepo.GetById(id);
            return MapearPregunta(respuesta);
        }

        public IEnumerable<Preguntas> ObtenerPorEncuestaId(int encuestaId)
        {
            var respuestas = _respuestaRepo.GetByEncuestaId(encuestaId);
            return (IEnumerable<Preguntas>)respuestas;
        }

        public IEnumerable<Preguntas> ObtenerPorTipoPregunta(TipoPregunta tipoPregunta)
        {
            var respuestas = _respuestaRepo.GetByTipoPregunta((int)tipoPregunta);
            return (IEnumerable<Preguntas>)respuestas;
        }

        public async Task UpdateTestAsync(Preguntas test)
        {
            var respuesta = MapearRespuesta(test);
            await _respuestaRepo.Update(respuesta);
        }

        // Métodos de mapeo
        private Respuestas MapearRespuesta(Preguntas pregunta)
        {
            return new Respuestas
            {
                Id = pregunta.Id,
                PreguntaId = pregunta.Id,
                RespuestaTexto = pregunta.Texto,
                UsuarioId = pregunta.UsuarioId,
                EncuentaId = pregunta.EncuestaId
            };
        }

        private Preguntas MapearPregunta(Respuestas respuesta)
        {
            return new Preguntas
            {
                Id = respuesta.Id,
                Texto = respuesta.RespuestaTexto,
                UsuarioId = respuesta.UsuarioId,
                EncuestaId = respuesta.EncuentaId,
                TipoPregunta = TipoPregunta.OpcionMultiple 
            };
        }


    }
}

