using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospital_del_Valle.Data;
using Hospital_del_Valle.Models;

namespace Hospital_del_Valle.Pages.Citas.CitasDoc
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
        ViewData["MedicoID"] = new SelectList(_context.Usuarios, "UsuarioID", "Apellido");
        ViewData["PacienteID"] = new SelectList(_context.Usuarios, "UsuarioID", "Apellido");
            return Page();
        }

        [BindProperty]
        public Cita Cita { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Si el modelo no es válido, registrar los errores
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("Error: " + error.ErrorMessage);  // Imprime los errores de validación en la consola
                }
                return Page();
            }

            // Intenta agregar la cita
            try
            {
                _context.Citas.Add(Cita);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Si ocurre una excepción, imprímela en la consola
                Console.WriteLine($"Error al guardar la cita: {ex.Message}");
                return Page();
            }
        }

    }
}
