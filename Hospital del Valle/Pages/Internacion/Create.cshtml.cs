using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Hospital_del_Valle.Pages.Internacion
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacienteHospitalizado Hospitalizacion { get; set; }
        public List<Usuario> Pacientes { get; set; }
        public List<Habitacion> Habitaciones { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Obtener la lista de pacientes y habitaciones disponibles
            Pacientes = await _context.Usuarios
                .Where(u => u.TipoUsuario == "Paciente")
                .ToListAsync();

            Habitaciones = await _context.Habitaciones
                .Where(h => h.Disponible == true)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Si la validación falla, recargar datos necesarios
                Pacientes = await _context.Usuarios
                    .Where(u => u.TipoUsuario == "Paciente")
                    .ToListAsync();

                Habitaciones = await _context.Habitaciones
                    .Where(h => h.Disponible == true)
                    .ToListAsync();

                return Page();
            }

            // Guardar la hospitalización
            _context.PacientesHospitalizados.Add(Hospitalizacion);

            // Actualizar disponibilidad de la habitación
            var habitacion = await _context.Habitaciones
                .FirstOrDefaultAsync(h => h.HabitacionID == Hospitalizacion.HabitacionID);

            if (habitacion != null)
            {
                habitacion.Disponible = false;
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/Internacion/Index");
        }
    }
}
