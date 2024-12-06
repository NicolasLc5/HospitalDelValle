using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_del_Valle.Models
{
    public class CitasReservas
    {
        [Key]
        public int ReservaID { get; set; }

        [Required]
        [ForeignKey(nameof(Paciente))]
        public int PacienteID { get; set; }

        [InverseProperty(nameof(Usuario.CitasReservadasComoPaciente))]
        public Usuario Paciente { get; set; }

        [Required]
        public DateTime FechaReserva { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; }

        public string Observaciones { get; set; }
    }
}
