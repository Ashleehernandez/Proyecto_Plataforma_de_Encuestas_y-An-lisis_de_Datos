using CapDominio.Entity;
using CapDominio.InterfaceRepository;
using CapInfraestructura.Context;


namespace CapInfraestructura.Repository
{
    public class PreguntaRepositoryGenery : GenericRepository<Preguntas>,
        IPreguntaRepositoryGenery
    {
        private readonly ContextoDB _context;
        public PreguntaRepositoryGenery(ContextoDB context) : base(context)
        {
            _context = context;
        }
      
        public Task<IEnumerable<Preguntas>> GetAllByEncuestaId(int id)
        {
            return Task.FromResult(_context.Preguntas.Where(x => x.EncuestaId == id).AsEnumerable());
        }

        object IPreguntaRepositoryGenery.GetAllByEncuestaId(int encuestaId)
        {
            return _context.Preguntas.Where(x => x.EncuestaId == encuestaId).ToList();

        }

        public object GetAllByEncuestaId(TipoPregunta tipoPregunta)
        {
            return _context.Preguntas.Where(x => x.TipoPregunta == tipoPregunta).ToList();
        }

        public IEnumerable<Preguntas> GetAllByTipoPregunta(TipoPregunta tipoPregunta)
        {
            return _context.Preguntas.Where(x => x.TipoPregunta == tipoPregunta).ToList();
        }
    }
    
}
