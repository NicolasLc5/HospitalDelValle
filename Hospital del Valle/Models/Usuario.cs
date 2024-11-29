using System.ComponentModel.DataAnnotations;

namespace Hospital_del_Valle.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [Required]
        [MaxLength(50)]
        public string TipoUsuario { get; set; } // Medico, Paciente, Enfermero, Farmacia

        [Required]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        public string Contraseña { get; set; }
        // Relación con las citas
        public ICollection<Cita> CitasComoPaciente { get; set; }
        public ICollection<Cita> CitasComoMedico { get; set; }

        // Relación con Prescripciones
        public ICollection<Prescripcion> PrescripcionesComoPaciente { get; set; }
        public ICollection<Prescripcion> PrescripcionesComoMedico { get; set; }
    }
}
