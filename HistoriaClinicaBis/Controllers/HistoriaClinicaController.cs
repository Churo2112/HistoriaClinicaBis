using HistoriaClinicaBis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HistoriaClinicaBis.Controllers
{
	public class HistoriaClinicaController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public HistoriaClinicaController(ApplicationDbContext context)
        {
            _context = context;
        }
	
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paciente == null)
            {
                return NotFound();
            }
            var registro = await _context.HistoriaClinica.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }
            return PartialView("~/Views/HistoriaClinica/_DetailsHC.cshtml", registro);
        }

        [Authorize]
        public async Task<IActionResult> Create(int id)
        {
            return View("~/Views/HistoriaClinica/_CreateHc.cshtml");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("idPaciente,fechaConsulta,motivoDeConsulta,estadoActual,diagnostico,tratamiento")] HistoriaClinica historiaClinica)
        {
            _context.HistoriaClinica.Add(historiaClinica);
            _context.SaveChanges();
            return RedirectToAction("Details", "Pacientes", new { id = historiaClinica.idPaciente });
        }
    }
}
