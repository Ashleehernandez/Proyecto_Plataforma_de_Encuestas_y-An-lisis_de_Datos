
using CapDominio.Entity;

namespace CapDominio.InterfaceRepository
{
    public interface IPreguntaRepositoryGenery : IGenericRepository<Preguntas>
    {
        object GetAllByEncuestaId(int encuestaId);
        object GetAllByEncuestaId(TipoPregunta tipoPregunta);
        IEnumerable<Preguntas> GetAllByTipoPregunta(TipoPregunta tipoPregunta);
    }
}
