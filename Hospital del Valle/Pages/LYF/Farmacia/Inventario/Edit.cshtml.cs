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

namespace Hospital_del_Valle.Pages.LYF.Farmacia.Inventario
{
    public class EditModel : PageModel
    {
        private readonly Hospital_del_Valle.Data.ApplicationDbContext _context;

        public EditModel(Hospital_del_Valle.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InventarioFarmacia InventarioFarmacia { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventariofarmacia =  await _context.InventarioFarmacia.FirstOrDefaultAsync(m => m.InventarioID == id);
            if (inventariofarmacia == null)
            {
                return NotFound();
            }
            InventarioFarmacia = inventariofarmacia;
           ViewData["MedicamentoID"] = new SelectList(_context.Medicamentos, "MedicamentoID", "Nombre");
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

            _context.Attach(InventarioFarmacia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioFarmaciaExists(InventarioFarmacia.InventarioID))
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

        private bool InventarioFarmaciaExists(int id)
        {
            return _context.InventarioFarmacia.Any(e => e.InventarioID == id);
        }
    }
}
