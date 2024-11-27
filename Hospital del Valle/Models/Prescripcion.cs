using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_del_Valle.Models
{
    public class Prescripcion



    {



        [Key]



        public int PrescripcionID { get; set; }



        [Required]


        [ForeignKey(nameof(Paciente))]

        public int PacienteID { get; set; }






        public Usuario Paciente { get; set; }



        [Required]


        [ForeignKey(nameof(Usuario))]

        public int MedicoID { get; set; }






        public Usuario Medico { get; set; }



        [Required]



        public DateTime FechaPrescripcion { get; set; } = DateTime.Now;



        [Required]

        [ForeignKey(nameof(Medicamento))]


        public int MedicamentoID { get; set; }






        public Medicamento medicamento { get; set; }



        public string Dosis { get; set; }



        public string Duracion { get; set; }



        public string Indicaciones { get; set; }



    }
}
