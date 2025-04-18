using CapDominio.Entity;
namespace CapDominio.InterfaceServicio
{
    public interface ITestService
    {
        Task<IEnumerable<Encuesta>> GetAllTestsAsync();
        Task<Encuesta> GetTestByIdAsync(int id);
        Task AddTestAsync(Encuesta test);
        Task<object> AddAndReturnIdAsync(Encuesta entity);
        Task UpdateTestAsync(Encuesta test);
        Task DeleteTestAsync(int id);
    }
}
