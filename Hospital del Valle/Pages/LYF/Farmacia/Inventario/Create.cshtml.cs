using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;

namespace Hospital_del_Valle.Pages.LYF.Farmacia.Inventario
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
        ViewData["MedicamentoID"] = new SelectList(_context.Medicamentos, "MedicamentoID", "Nombre");
            return Page();
        }

        [BindProperty]
        public InventarioFarmacia InventarioFarmacia { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InventarioFarmacia.Add(InventarioFarmacia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
