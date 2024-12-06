using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;

namespace Hospital_del_Valle.Pages.Citas.CitasLabo
{
    public class CreateModel : PageModel
    {
        private readonly Hospital_del_Valle.Data.ApplicationDbContext _context;

        public CreateModel(Hospital_del_Valle.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Asegúrate de cargar la lista de pacientes para el campo select
            ViewData["PacienteID"] = new SelectList(_context.Usuarios, "UsuarioID", "Apellido");
            return Page();
        }

        [BindProperty]
        public CitasReservas CitasReservas { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Añadir la nueva cita a la base de datos
            _context.CitasReservas.Add(CitasReservas);
            await _context.SaveChangesAsync();

            // Redirigir al listado de citas
            return RedirectToPage("./Index");
        }
    }
}
