using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_del_Valle.Models
{
    public class PacienteHospitalizado

    {

        [Key]
        public int HospitalizacionID { get; set; }


        [Required]
        [ForeignKey(nameof(Usuario))]
        public int PacienteID { get; set; }
        public Usuario Paciente { get; set; }


        [Required]
        [ForeignKey(nameof(Habitacion))]
        public int HabitacionID { get; set; }
        // Relación con la entidad Habitación
        public Habitacion Habitacion { get; set; }


        [Required]
        [ForeignKey(nameof(Usuario))]
        public int MedicoID { get; set; }
        // Relación con la entidad Usuario (Médico responsable)
        public Usuario MedicoResponsable { get; set; }


        [ForeignKey(nameof(Usuario))]
        public int? EnfermeroID { get; set; }
        // Relación opcional con la entidad Usuario (Enfermero encargado)
        public Usuario? EnfermeroEncargado { get; set; }


        [Required]
        public DateTime FechaIngreso { get; set; }


        public DateTime? FechaAlta { get; set; }

        public string NotasSeguimiento { get; set; }

        [Required]

        [MaxLength(50)]

        public string Estado { get; set; } // Ingresado, Alta


        public ICollection<HistorialClinico>? HistorialesClinicos { get; set; }
        // Relación con pruebas de laboratorio durante la hospitalización
        public ICollection<PruebaLaboratorio>? PruebasLaboratorio { get; set; }
    }
}
