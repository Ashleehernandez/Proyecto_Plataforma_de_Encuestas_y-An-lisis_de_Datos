using CapDominio.Entity;
using CapDominio.InterfaceRepository;
using CapInfraestructura.Context;

namespace CapInfraestructura.Repository
{
    public class TestRepository : GenericRepository<Encuesta>, ITestRepository
    {
        private readonly ContextoDB _context;
        public TestRepository(ContextoDB context) : base(context)
        {
            _context = context;
        }
        
    }
}
