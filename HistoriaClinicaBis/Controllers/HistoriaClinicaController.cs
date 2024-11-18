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

            var hc = await _context.HistoriaClinica
                .FirstOrDefaultAsync(m => m.idHistoria == id);
            if (hc == null)
            {
                return NotFound();
            }

            return View(hc);
        }
    }
}
