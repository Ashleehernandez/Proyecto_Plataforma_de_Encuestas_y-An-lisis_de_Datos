using CapDominio.Entity;
using CapDominio.InterfaceRepository;
using CapDominio.InterfaceServicio;

namespace CapAplicacion.Servicio
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public  Task AddTestAsync(Encuesta test)
        {

            try
            {
                return _testRepository.Add(test);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task DeleteTestAsync(int id)
        {
            return _testRepository.Delete(id);
        }

        public Task<IEnumerable<Encuesta>> GetAllTestsAsync()
        {
            return _testRepository.GetAll();
        }

        public Task<Encuesta> GetTestByIdAsync(int id)
        {
            return _testRepository.GetById(id);
        }

        public Task UpdateTestAsync(Encuesta test)
        {
            return _testRepository.Update(test);
        }
    }
}
