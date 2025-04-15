
namespace CAPdominioProyectofinal.InterfaceServicio
{
    public interface IPreguntasServicio
    {
        Task<IEnumerable<Preguntas>> GetAllTestsAsync();
        Task<Preguntas> GetTestByIdAsync(int id);
        Task AddTestAsync(Preguntas test);
        Task UpdateTestAsync(Preguntas test);
        Task DeleteTestAsync(int id);

        IEnumerable<Preguntas> ObtenerPorTipoPregunta(TipoPregunta tipoPregunta);
        IEnumerable<Preguntas> ObtenerPorEncuestaId(int encuestaId);
    }
}
