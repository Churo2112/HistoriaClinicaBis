using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
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
        [DisplayName("Fecha de Consulta")]
        public string fechaConsulta { get; set; }
        [DisplayName("Motivo de consulta")]
        public string motivoDeConsulta { get; set; }
        [DisplayName("Estado actual")]
        public string estadoActual { get; set; }
        [DisplayName("Diagnóstico")]
        public string diagnostico { get; set; }
        [DisplayName("Tratamiento")]
        public string tratamiento { get; set; }

        public HistoriaClinica() { }
    }
}
