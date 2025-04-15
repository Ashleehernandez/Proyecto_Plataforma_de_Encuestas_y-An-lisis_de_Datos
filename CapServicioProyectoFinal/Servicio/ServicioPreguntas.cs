using CapDominio.InterfaceRepository;
using CAPdominioProyectofinal.InterfaceServicio;



namespace CapAplicacion.Servicio
{
    public class ServicioPreguntas : IPreguntasServicio
    {
        private readonly IPreguntaRepositoryGenery preguntasRepository;

        public ServicioPreguntas(IPreguntaRepositoryGenery preguntasRepositor)
        {
            preguntasRepository = preguntasRepositor;
        }

        public Task AddTestAsync(Preguntas test)
        {
            return preguntasRepository.Add(test);
        }

        public Task DeleteTestAsync(int id)
        {
            return preguntasRepository.Delete(id);
        }

        public Task<IEnumerable<Preguntas>> GetAllTestsAsync()
        {
            return preguntasRepository.GetAll();
        }

        public Task<Preguntas> GetTestByIdAsync(int id)
        {
            return preguntasRepository.GetById(id);
        }

        public IEnumerable<Preguntas> ObtenerPorEncuestaId(int encuestaId)
        {
            return (IEnumerable<Preguntas>)preguntasRepository.GetAllByEncuestaId(encuestaId);
        }

        public IEnumerable<Preguntas> ObtenerPorTipoPregunta(TipoPregunta tipoPregunta)
        {
            return preguntasRepository.GetAllByTipoPregunta(tipoPregunta);
        }

        public Task UpdateTestAsync(Preguntas test)
        {
           return preguntasRepository.Update(test);
        }
    }
}
