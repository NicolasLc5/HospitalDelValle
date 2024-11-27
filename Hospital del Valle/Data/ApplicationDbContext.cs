using Hospital_del_Valle.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_del_Valle.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cita> Citas { get; set; }

        public DbSet<HistorialClinico> HistorialClinico { get; set; }

        public DbSet<Medicamento> Medicamentos { get; set; }

        public DbSet<Prescripcion> Prescripciones { get; set; }

        public DbSet<PruebaLaboratorio> PruebasLaboratorio { get; set; }

        public DbSet<PacienteHospitalizado> PacientesHospitalizados { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<InventarioFarmacia> InventarioFarmacia { get; set; }

        public DbSet<SolicitudMaterial> SolicitudesMateriales { get; set; }

        public DbSet<Notificacion> Notificaciones { get; set; }



    }
}
       

