using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;

namespace Hospital_del_Valle.Pages.LYF.Farmacia.Medicamentos
{
    public class DetailsModel : PageModel
    {
        private readonly Hospital_del_Valle.Data.ApplicationDbContext _context;

        public DetailsModel(Hospital_del_Valle.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Medicamento Medicamento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos.FirstOrDefaultAsync(m => m.MedicamentoID == id);
            if (medicamento == null)
            {
                return NotFound();
            }
            else
            {
                Medicamento = medicamento;
            }
            return Page();
        }
    }
}
