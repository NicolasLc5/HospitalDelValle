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

        public DbSet<Habitacion> Habitaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(u => u.CitasComoPaciente)
                .HasForeignKey(c => c.PacienteID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(u => u.CitasComoMedico)
                .HasForeignKey(c => c.MedicoID)
                .OnDelete(DeleteBehavior.Restrict);
            

            modelBuilder.Entity<Prescripcion>()
                .HasOne(p => p.Paciente)
                .WithMany(u => u.PrescripcionesComoPaciente)
                .HasForeignKey(p => p.PacienteID)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Prescripcion>()
                .HasOne(p => p.Medico)
                .WithMany(u => u.PrescripcionesComoMedico) 
                .HasForeignKey(p => p.MedicoID)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Prescripcion>()
                .HasOne(p => p.Medicamento)
                .WithMany() // Si no hay una relación inversa
                .HasForeignKey(p => p.MedicamentoID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PruebaLaboratorio>()
                .HasOne(pl => pl.Medico)
                .WithMany()
                .HasForeignKey(pl => pl.MedicoID)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<PruebaLaboratorio>()
                .HasOne(pl => pl.Paciente)
                .WithMany()
                .HasForeignKey(pl => pl.PacienteID)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PacienteHospitalizado>()
                .HasOne(ph => ph.Paciente)
                .WithMany(u => u.HospitalizacionesComoPaciente)
                .HasForeignKey(ph => ph.PacienteID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PacienteHospitalizado>()
                .HasOne(ph => ph.MedicoResponsable)
                .WithMany(u => u.HospitalizacionesComoMedico)
                .HasForeignKey(ph => ph.MedicoID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PacienteHospitalizado>()
                .HasOne(ph => ph.EnfermeroEncargado)
                .WithMany(u => u.HospitalizacionesComoEnfermero)
                .HasForeignKey(ph => ph.EnfermeroID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PacienteHospitalizado>()
                .HasOne(ph => ph.Habitacion)
                .WithMany(h => h.Hospitalizaciones)
                .HasForeignKey(ph => ph.HabitacionID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Habitacion>()
                .Property(h => h.Disponible)
                .HasDefaultValue(true);

        }

    }
}
       

