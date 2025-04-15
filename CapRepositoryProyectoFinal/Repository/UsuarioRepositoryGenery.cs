using CapDominio.Entity;
using CapInfraestructura.Context;


namespace CapInfraestructura.Repository
{
    using CapDominio.InterfaceRepository;
    

    namespace CapInfraestructura.Repository
    {
        public class UsuarioRepositoryGenery : GenericRepository<Usuario>, IUsuarioRepositoryGenery
        {
            private readonly ContextoDB contextoDB;

            public UsuarioRepositoryGenery(ContextoDB context) :base(context)
            {
                contextoDB = context;
            }
        }
    }
}

