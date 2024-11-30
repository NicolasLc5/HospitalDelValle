using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_del_Valle.Models
{
    public class InventarioFarmacia
    {
        [Key]
        public int InventarioID { get; set; }
        [Required]
        [ForeignKey(nameof(Medicamento))]
        public int MedicamentoID { get; set; }
        public Medicamento medicamento { get; set; }
        [Required]
        public int StockActual { get; set; }
        [Required]
        public DateTime FechaUltimaActualizacion { get; set; } = DateTime.Now;
    }
}
