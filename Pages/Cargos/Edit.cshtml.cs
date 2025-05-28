using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Cargos
{
    public class EditModel : PageModel
    {
        private readonly HRManagerContext _context;

        public EditModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cargo Cargo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Cargo = await _context.Cargos.FindAsync(id);

            if (Cargo == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Adjunta el objeto al contexto y marca como modificado
            _context.Attach(Cargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(Cargo.IdCargo))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("Index");
        }

        private bool CargoExists(int id)
        {
            return _context.Cargos.Any(e => e.IdCargo == id);
        }
    }
}