using CapDominio.Entity;
namespace CAPdominioProyectofinal.InterfaceServicio
{
    public interface IUsuarioServicio
    {
        Task<IEnumerable<Usuario>> GetAllTestsAsync();
        Task<Usuario> GetTestByIdAsync(int id);
        Task AddTestAsync(Usuario test);
        Task UpdateTestAsync(Usuario test);
        Task DeleteTestAsync(int id);

        Usuario Obtenerporcorreo(string correo);
        Usuario Autenticar(string correo, string contrasena);
        IEnumerable<Usuario> ObtecnerPorRol(Rol rol);

    }
}
