using CapDominio.Entity;
namespace CapDominio.InterfaceServicio
{
    public interface ITestService
    {
        Task<IEnumerable<Encuesta>> GetAllTestsAsync();
        Task<Encuesta> GetTestByIdAsync(int id);
        Task AddTestAsync(Encuesta test);
        Task UpdateTestAsync(Encuesta test);
        Task DeleteTestAsync(int id);
    }
}
