using System.ComponentModel.DataAnnotations;

namespace Hospital_del_Valle.Models
{
    public class Medicamento
    {
        [Key]
        public int MedicamentoID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public DateTime FechaVencimiento { get; set; }
    }
}
