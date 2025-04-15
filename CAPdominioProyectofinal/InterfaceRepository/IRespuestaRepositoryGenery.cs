using CapDominio.Entity;
namespace CapDominio.InterfaceRepository
{
    public interface IRespuestaRepositoryGenery : IGenericRepository<Respuestas>
    {
        IEnumerable<Preguntas> GetByTipoPregunta(int tipoPregunta);
        IEnumerable<Encuesta> GetByEncuestaId(int encuestaId);
    }
}
