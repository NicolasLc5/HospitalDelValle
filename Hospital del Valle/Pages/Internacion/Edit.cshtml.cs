using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Hospital_del_Valle.Pages.Internacion
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacienteHospitalizado Hospitalizacion { get; set; }
        public List<Usuario> Pacientes { get; set; }
        public List<Habitacion> Habitaciones { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Buscar hospitalización
            Hospitalizacion = await _context.PacientesHospitalizados
                .FirstOrDefaultAsync(h => h.HospitalizacionID == id);

            if (Hospitalizacion == null)
            {
                return NotFound();
            }

            // Obtener pacientes y habitaciones
            Pacientes = await _context.Usuarios
                .Where(u => u.TipoUsuario == "Paciente")
                .ToListAsync();

            Habitaciones = await _context.Habitaciones.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Cargar datos necesarios si falla la validación
                Pacientes = await _context.Usuarios
                    .Where(u => u.TipoUsuario == "Paciente")
                    .ToListAsync();

                Habitaciones = await _context.Habitaciones.ToListAsync();

                return Page();
            }

            // Actualizar hospitalización
            _context.Attach(Hospitalizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalizacionExists(Hospitalizacion.HospitalizacionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/PacienteHospitalizado/Index");
        }

        private bool HospitalizacionExists(int id)
        {
            return _context.PacientesHospitalizados.Any(e => e.HospitalizacionID == id);
        }
    }
}
