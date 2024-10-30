using DocsAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DocsAgenda.Controllers;
using Microsoft.EntityFrameworkCore;
using DocsAgenda.Data;
using DocsAgenda.Interfaces.Usuarios;

namespace DocsAgenda.Services
{
    #region Usuarios
    
    public class UsuariosServices
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosServices(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task<List<Usuario>> ObtenerTodosLosUsuariosAsync()
        {
            return await _usuariosRepository.ObtenerUsuariosAsync();
        }

    }

    #endregion

}
