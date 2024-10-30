using DocsAgenda.Models;
namespace DocsAgenda.Interfaces.Usuarios
{
    public interface IUsuariosRepository
    {
        Task<List<Usuario>> ObtenerUsuariosAsync();
        Task<Usuario> ObtenerUsuarioPorIdAsync(string NomUser);
    }
}
