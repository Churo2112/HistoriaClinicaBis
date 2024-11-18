using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HistoriaClinicaBis.Models
{
    public class Paciente
    {

        protected readonly ApplicationDbContext _context;
        public Paciente(ApplicationDbContext context) => _context = context;


        [Key]
        public int id { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Apellido")]
        public string apellido { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        public string fechaNacimiento { get; set; }

        [DisplayName("DNI")]
        public int dni { get; set; }

        [DisplayName("Cobertura")]
        public string cobertura { get; set; }

        [DisplayName("Correo Electrónico")]
        public string mail { get; set; }

        [DisplayName("Telefóno")]
        public string telefono { get; set; }

        [DisplayName("Antecedentes Familiares")]
        public string antecedentesFamiliares { get; set; }

        public Paciente() { }

    }
}
