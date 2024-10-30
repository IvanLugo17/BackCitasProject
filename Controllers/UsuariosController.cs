using DocsAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DocsAgenda.Services;
using DocsAgenda.Data;
using Microsoft.EntityFrameworkCore;

namespace DocsAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly DataContext _context;
        public UsuariosController(DataContext context, ILogger<UsuariosController> logger)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet("consulta")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.AdmUsuarios.ToListAsync();
        }

        [HttpGet("user/{user}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioUser(string user)
        {
            var usuarios = await _context.AdmUsuarios
                .Where(u => u.NomUser.Contains(user))
                .ToListAsync();

            if (usuarios == null || !usuarios.Any())
            {
                return NotFound();
            }

            return usuarios;
        }


        [HttpPost("register")]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            // Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AdmUsuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Retornar el producto creado con su Id
            return CreatedAtAction(nameof(GetUsuarioUser), new { user = usuario.NomUser }, usuario);
        }

        #region BASE

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return base.View(new Models.Models { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
