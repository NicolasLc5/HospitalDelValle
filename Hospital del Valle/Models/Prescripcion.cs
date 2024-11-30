using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_del_Valle.Models
{
    public class Prescripcion
    {
        [Key]
        public int PrescripcionID { get; set; }

        [Required]
        [ForeignKey(nameof(Paciente))]
        public int PacienteID { get; set; }

        // Relación con la entidad Usuario (Paciente)
        [InverseProperty("PrescripcionesComoPaciente")]
        public Usuario? Paciente { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]
        public int MedicoID { get; set; }

        // Relación con la entidad Usuario (Medico)
        [InverseProperty("PrescripcionesComoMedico")]
        public Usuario? Medico { get; set; }

        [Required]
        public DateTime FechaPrescripcion { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey(nameof(Medicamento))]
        public int MedicamentoID { get; set; }

        public Medicamento? Medicamento { get; set; }

        public string Dosis { get; set; }
        public string Duracion { get; set; }
        public string Indicaciones { get; set; }
    }
}
