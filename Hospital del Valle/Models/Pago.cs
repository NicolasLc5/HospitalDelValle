using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_del_Valle.Models
{
    public class Pago

    {

        [Key]

        public int PagoID { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]

        public int PacienteID { get; set; }


        public Usuario Paciente { get; set; }

        [Required]

        public decimal Monto { get; set; }

        [Required]

        public DateTime FechaPago { get; set; } = DateTime.Now;

        public string Descripcion { get; set; }

    }
}
