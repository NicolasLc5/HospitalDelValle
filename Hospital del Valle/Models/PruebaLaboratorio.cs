using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_del_Valle.Models
{
    public class PruebaLaboratorio

    {

        [Key]

        public int PruebaID { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]

        public int PacienteID { get; set; }


        public Usuario Paciente { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]

        public int MedicoID { get; set; }


        public Usuario Medico { get; set; }

        [Required]

        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        [Required]

        [MaxLength(100)]

        public string TipoPrueba { get; set; }

        public string Resultados { get; set; }

        [Required]

        [MaxLength(50)]

        public string Estado { get; set; } // Pendiente, Completado


        [ForeignKey(nameof(PacienteHospitalizado))]
        public int? HospitalizacionID { get; set; }
        // Relación con la hospitalización
        public PacienteHospitalizado? Hospitalizacion { get; set; }

    }
}
