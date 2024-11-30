using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;

namespace Hospital_del_Valle.Pages.LYF.Farmacia.Recibir
{
    public class DetailsModel : PageModel
    {
        private readonly Hospital_del_Valle.Data.ApplicationDbContext _context;

        public DetailsModel(Hospital_del_Valle.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Prescripcion Prescripcion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescripcion = await _context.Prescripciones.FirstOrDefaultAsync(m => m.PrescripcionID == id);
            if (prescripcion == null)
            {
                return NotFound();
            }
            else
            {
                Prescripcion = prescripcion;
            }
            return Page();
        }
    }
}
