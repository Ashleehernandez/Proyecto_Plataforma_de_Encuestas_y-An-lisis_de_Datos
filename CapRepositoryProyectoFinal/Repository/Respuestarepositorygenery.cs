
using CapDominio.Entity;
using CapInfraestructura.Context;
using CapDominio.InterfaceRepository;

namespace CapInfraestructura.Repository
{
    public class Respuestarepositorygenery : GenericRepository<Respuestas> ,
         IRespuestaRepositoryGenery
    {
        private readonly ContextoDB _context;
        public Respuestarepositorygenery(ContextoDB context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Encuesta> GetByEncuestaId(int encuestaId)
        {
            return (IEnumerable<Encuesta>)_context.Respuestas
                .Where(x => x.EncuentaId == encuestaId)
                .Select(x => x.EncuentaId)
                .ToList();
        }

        public IEnumerable<Preguntas> GetByTipoPregunta(int tipoPregunta)
        {
            return (IEnumerable<Preguntas>)_context.Respuestas
                .Where(x => x.PreguntaId == tipoPregunta)
                .Select(x => x.PreguntaId)
                .ToList();
        }
    }
 
}
