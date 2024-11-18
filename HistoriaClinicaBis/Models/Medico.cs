using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HistoriaClinicaBis.Models
{
    public class Medico
    {

        protected readonly ApplicationDbContext _context;
        public Medico(ApplicationDbContext context) => _context = context;


        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Apellido { get; set; }
        public int Matricula { get; set; }
        public string Especialidad { get; set; }
        public string Password { get; set; }


    }
}
