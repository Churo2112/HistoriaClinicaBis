using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HistoriaClinicaBis.Models
{
    public class HistoriaClinica
    {

        protected readonly ApplicationDbContext _context;
        public HistoriaClinica(ApplicationDbContext context) => _context = context;

        [Key]
        public int idHistoria { get; set; }
        public int idPaciente { get; set; }
        public string fechaConsulta { get; set; }
        public string motivoDeConsulta { get; set; }
        public string estadoActual { get; set; }
        public string diagnostico { get; set; }
        public string tratamiento { get; set; }

        public HistoriaClinica() { }
    }
}
