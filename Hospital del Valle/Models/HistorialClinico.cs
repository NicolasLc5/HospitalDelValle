using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_del_Valle.Models
{
    public class HistorialClinico

    {

        [Key]

        public int HistorialID { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]

        public int PacienteID { get; set; }



        public Usuario Paciente { get; set; }

        [Required]

        public DateTime FechaActualizacion { get; set; } = DateTime.Now;

        [Required]

        public string NotasClinicas { get; set; }

        public string Diagnostico { get; set; }

        public string Tratamiento { get; set; }

    }
}
