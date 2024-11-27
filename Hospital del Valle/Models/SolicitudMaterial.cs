using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_del_Valle.Models
{
    public class SolicitudMaterial

    {

        [Key]

        public int SolicitudID { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]

        public int EnfermeroID { get; set; }


        public Usuario Enfermero { get; set; }

        [Required]

        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        public string Detalles { get; set; }

        [Required]

        [MaxLength(50)]

        public string Estado { get; set; } // Pendiente, Aprobado, Rechazado

    }
}
