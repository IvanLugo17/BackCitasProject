using DocsAgenda.Interfaces.Usuarios;
using DocsAgenda.Data;
using DocsAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace DocsAgenda.Interfaces.Usuarios
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly DataContext _context;

        public UsuariosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return await _context.AdmUsuarios.ToListAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorIdAsync(string NomUser)
        {
            return await _context.AdmUsuarios.FindAsync(NomUser);
        }

    }
}
