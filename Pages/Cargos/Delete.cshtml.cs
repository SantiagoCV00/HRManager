using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Cargos
{
    public class DeleteModel : PageModel
    {
        private readonly HRManagerContext _context;

        public DeleteModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cargo Cargo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Cargo = await _context.Cargos
                .Include(c => c.Empleados)
                .FirstOrDefaultAsync(m => m.IdCargo == id);

            if (Cargo == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Cargo = await _context.Cargos.FindAsync(id);

            if (Cargo != null)
            {
                _context.Cargos.Remove(Cargo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}