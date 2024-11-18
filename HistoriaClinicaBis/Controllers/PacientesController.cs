using HistoriaClinicaBis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HistoriaClinicaBis.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacientesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize]
        public async Task<IActionResult> busquedaPorDni(int dni)
        {
            var pacientes = from paciente in _context.Paciente select paciente;

            pacientes = pacientes.Where(p => p.dni.Equals(dni));

            return View("busquedaPaciente", await pacientes.ToListAsync());
        }


        [Authorize]
        public async Task<IActionResult> busquedaPorNombre(string nombre, string apellido)
        {
            var pacientes = from paciente in _context.Paciente select paciente;

            //Acá incluí que deben hallarse ambos, ¿o sería mejor un OR?
            pacientes = pacientes.Where(p => p.nombre!.Contains(nombre) && p.apellido!.Contains(apellido));

            return View("busquedaPaciente", await pacientes.ToListAsync());
        }


        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paciente == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente
                .FirstOrDefaultAsync(m => m.id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            IQueryable<HistoriaClinica> hc = _context.HistoriaClinica.Where(hc => hc.idPaciente == paciente.id);
            ViewData["historiasClinicas"] = hc.ToList();

            return View(paciente);
        }


        [Authorize]
        public async Task<IActionResult> Edit(int? id, int op)
        {
            if (id == null || _context.Paciente == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }


            if (op == 2)
            {
                return PartialView("_RegFamiliar", paciente);
            }
            return PartialView("_Edit", paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(Paciente paciente)
        {
            _context.Paciente.Update(paciente);
            _context.SaveChanges();
            return RedirectToAction("Details", new { paciente.id });
        }

    }
}
