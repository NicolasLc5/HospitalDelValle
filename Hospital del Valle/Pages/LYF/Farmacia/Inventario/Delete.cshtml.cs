using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;

namespace Hospital_del_Valle.Pages.LYF.Farmacia.Inventario
{
    public class DeleteModel : PageModel
    {
        private readonly Hospital_del_Valle.Data.ApplicationDbContext _context;

        public DeleteModel(Hospital_del_Valle.Data.ApplicationDbContext context)
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

            var inventariofarmacia = await _context.InventarioFarmacia.FirstOrDefaultAsync(m => m.InventarioID == id);

            if (inventariofarmacia == null)
            {
                return NotFound();
            }
            else
            {
                InventarioFarmacia = inventariofarmacia;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventariofarmacia = await _context.InventarioFarmacia.FindAsync(id);
            if (inventariofarmacia != null)
            {
                InventarioFarmacia = inventariofarmacia;
                _context.InventarioFarmacia.Remove(InventarioFarmacia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
