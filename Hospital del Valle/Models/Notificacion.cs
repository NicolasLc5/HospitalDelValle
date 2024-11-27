using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_del_Valle.Models
{
    public class Notificacion
    {
        [Key]
        public int NotificacionID { get; set; }
        [Required]
        [ForeignKey(nameof(Usuario))]
        public int UsuarioID { get; set; }

        public Usuario usuario { get; set; }
        [Required]
        public string Mensaje { get; set; }
        [Required]
        public DateTime FechaNotificacion { get; set; } = DateTime.Now;
        public bool Leido { get; set; } = false;
    }
}
