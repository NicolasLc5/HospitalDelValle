using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;

namespace Hospital_del_Valle.Pages.LYF.Farmacia.Medicamentos
{
    public class EditModel : PageModel
    {
        private readonly Hospital_del_Valle.Data.ApplicationDbContext _context;

        public EditModel(Hospital_del_Valle.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medicamento Medicamento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento =  await _context.Medicamentos.FirstOrDefaultAsync(m => m.MedicamentoID == id);
            if (medicamento == null)
            {
                return NotFound();
            }
            Medicamento = medicamento;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Medicamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentoExists(Medicamento.MedicamentoID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MedicamentoExists(int id)
        {
            return _context.Medicamentos.Any(e => e.MedicamentoID == id);
        }
    }
}
