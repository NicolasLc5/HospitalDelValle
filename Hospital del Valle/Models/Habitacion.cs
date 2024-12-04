using System.ComponentModel.DataAnnotations;

namespace Hospital_del_Valle.Models
{
    public class Habitacion
    {
        [Key]
        public int HabitacionID { get; set; }

        [Required]
        [MaxLength(10)]
        public string Numero { get; set; } // Número de la habitación

        [Required]
        [MaxLength(20)]
        public string Tipo { get; set; } // Ejemplo: General, Privada, UCI

        [Required]
        public bool Disponible { get; set; } = true; // Indica si está disponible para nuevas hospitalizaciones

        [Required]
        public decimal CostoDiario { get; set; }

        // Relación con las hospitalizaciones
        public ICollection<PacienteHospitalizado>? Hospitalizaciones { get; set; }
    }

}
