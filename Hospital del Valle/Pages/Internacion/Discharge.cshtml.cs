using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.EntityFrameworkCore;


namespace Hospital_del_Valle.Pages.Internacion
{
    public class DischargeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DischargeModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacienteHospitalizado Hospitalizacion { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            //Hospitalizacion = await _context.PacientesHospitalizados
            //    .Include(h => h.Paciente)
            //    .FirstOrDefaultAsync(m => m.HospitalizacionID == id);

            //if (Hospitalizacion == null)
            //{
            //    return NotFound();
            //}

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var hospitalizacionToUpdate = await _context.PacientesHospitalizados.FindAsync(id);

            if (hospitalizacionToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(
                hospitalizacionToUpdate,
                "Hospitalizacion",
                h => h.FechaAlta,
                h => h.Estado,
                h => h.NotasSeguimiento))
            {
                hospitalizacionToUpdate.FechaAlta = DateTime.Now; // Registrar fecha de alta
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
