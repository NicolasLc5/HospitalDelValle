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

        public DateTime FechaIngreso { get; set; }

        public DateTime? FechaAlta { get; set; }

        public string NotasSeguimiento { get; set; }

        [Required]

        [MaxLength(50)]

        public string Estado { get; set; } // Ingresado, Alta

    }
}
