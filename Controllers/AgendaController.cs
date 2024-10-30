using DocsAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DocsAgenda.Services;
using DocsAgenda.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace DocsAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : Controller
    {
        private readonly ILogger<AgendaController> _logger;
        private readonly DataContext _context;
        public AgendaController(DataContext context, ILogger<AgendaController> logger)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet("consultaHorarios")]
        public List<string> GetHorario()
        {
            List<string> horarios = new List<string>();
            horarios.Add("10:00");
            horarios.Add("10:30");
            horarios.Add("11:00");
            horarios.Add("11:30");
            horarios.Add("12:00");
            horarios.Add("12:30");
            horarios.Add("13:00");
            horarios.Add("13:30");
            horarios.Add("14:00");
            horarios.Add("14:30");
            horarios.Add("15:00");
            horarios.Add("15:30");
            horarios.Add("16:00");
            return horarios;
        }

        [HttpGet("consultaAgendas")]
        public async Task<ActionResult<IEnumerable<Agenda>>> GetAgenda()
        {
            return await _context.CtaAgenda.ToListAsync();
        }

        [HttpGet("docAgenda/{idDoc}")]
        public async Task<ActionResult<IEnumerable<Agenda>>> GetOneDoctorAgenda(int idDoc, DateTime date)
        {
            IQueryable<Agenda> query = _context.CtaAgenda;

            query = query.Where(a => a.IdDoctor.Equals(idDoc));

            var Agendas = await query.ToListAsync();

            if (Agendas == null || !Agendas.Any())
            {
                return NotFound();
            }

            return Agendas;
        }

        [HttpGet("docfiltros/{idDoc}/{date}")]
        public async Task<ActionResult<IEnumerable<Agenda>>> GetOneDoctorAgendaFiltros(int idDoc,DateTime date)
        {
            IQueryable<Agenda> query = _context.CtaAgenda;
            
           query = query.Where(a => a.IdDoctor.Equals(idDoc));

           query = query.Where(da => da.Fecha == date);
                
              var Agendas = await query.ToListAsync();

            if (Agendas == null || !Agendas.Any())
            {
                return NotFound();
            }

            return Agendas;
        }

        [HttpPost("registrarCita")]
        public async Task<ActionResult<Agenda>> CreateCita(Agenda agenda)
        {
            // Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CtaAgenda.Add(agenda);
            await _context.SaveChangesAsync();

            // Retornar el producto creado con su Id
            return CreatedAtAction(nameof(GetAgenda), new { cita = agenda.CorreoPaciente }, agenda);
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
