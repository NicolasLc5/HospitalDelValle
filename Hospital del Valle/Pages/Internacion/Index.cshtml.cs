using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Hospital_del_Valle.Pages.Internacion
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<PacienteHospitalizado> PacientesHospitalizados { get; set; }
        public List<Habitacion> Habitaciones { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BusquedaNombre { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BusquedaEstado { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BusquedaHabitacion { get; set; }

        public async Task OnGetAsync()
        {
            // Obtener habitaciones para filtros
            Habitaciones = await _context.Habitaciones.ToListAsync();

            // Base de datos de hospitalizaciones
            var query = _context.PacientesHospitalizados
                .Include(ph => ph.Paciente)
                .Include(ph => ph.Habitacion)
                .AsQueryable();

            // Aplicar filtros
            if (!string.IsNullOrEmpty(BusquedaNombre))
            {
                query = query.Where(ph => EF.Functions.Like(ph.Paciente.Nombre, $"%{BusquedaNombre}%"));
            }

            if (!string.IsNullOrEmpty(BusquedaEstado))
            {
                query = query.Where(ph => ph.Estado == BusquedaEstado);
            }

            if (!string.IsNullOrEmpty(BusquedaHabitacion))
            {
                query = query.Where(ph => ph.Habitacion.HabitacionID.ToString() == BusquedaHabitacion);
            }

            PacientesHospitalizados = await query.ToListAsync();
        }
    }
}
