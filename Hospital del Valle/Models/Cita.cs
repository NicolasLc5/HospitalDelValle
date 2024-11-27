using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_del_Valle.Models
{
    public class Cita
    {
        [Key]
        public int CitaID { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]

        public int PacienteID { get; set; }

        // Relación con la entidad Usuario (Paciente)
        public Usuario Paciente { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]

        public int MedicoID { get; set; }

        // Relación con la entidad Usuario (Medico)
        public Usuario Medico { get; set; }

        [Required]
        public DateTime FechaCita { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } // Programada, Cancelada, Finalizada

        public string Observaciones { get; set; }
    }
}
