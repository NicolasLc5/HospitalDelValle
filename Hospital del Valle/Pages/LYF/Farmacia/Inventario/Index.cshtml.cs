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
    public class IndexModel : PageModel
    {
        private readonly Hospital_del_Valle.Data.ApplicationDbContext _context;

        public IndexModel(Hospital_del_Valle.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<InventarioFarmacia> InventarioFarmacia { get;set; } = default!;

        public async Task OnGetAsync()
        {
            InventarioFarmacia = await _context.InventarioFarmacia
                .Include(i => i.medicamento).ToListAsync();
        }
    }
}
