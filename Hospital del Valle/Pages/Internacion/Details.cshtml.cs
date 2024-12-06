using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Hospital_del_Valle.Pages.Internacion
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PacienteHospitalizado Hospitalizacion { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            //Hospitalizacion = await _context.PacientesHospitalizados
            //    .Include(h => h.Paciente)
            //    .Include(h => h.Habitacion)
            //    .FirstOrDefaultAsync(m => m.HospitalizacionID == id);

            //if (Hospitalizacion == null)
            //{
            //    return NotFound();
            //}

            return Page();
        }
    }
}
