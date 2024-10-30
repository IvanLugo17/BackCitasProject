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
    public class DoctoresController : Controller
    {
        private readonly ILogger<DoctoresController> _logger;
        private readonly DataContext _context;
        public DoctoresController(DataContext context, ILogger<DoctoresController> logger)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet("consultaDoc")]
        public async Task<ActionResult<IEnumerable<Doctores>>> GetDoctors()
        {
            return await _context.CatDoctores.ToListAsync();
        }

        [HttpGet("docs/{doc}")]
        public async Task<ActionResult<IEnumerable<Doctores>>> GetOneDoctor(string doc)
        {
            var doctor = await _context.CatDoctores
                .Where(d => d.NomDoctor.Contains(doc))
                .ToListAsync();

            if (doctor == null || !doctor.Any())
            {
                return NotFound();
            }

            return doctor;
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
