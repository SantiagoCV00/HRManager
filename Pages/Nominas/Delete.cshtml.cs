using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HRManager.Pages.Nominas
{
    public class DeleteModel : PageModel
    {
        private readonly HRManagerContext _context;

        public DeleteModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nomina Nomina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

     
            Nomina = await _context.Nominas
                .Include(n => n.Empleado)
                .FirstOrDefaultAsync(m => m.IdNomina == id);

            if (Nomina == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Nomina = await _context.Nominas.FindAsync(id);

            if (Nomina != null)
            {
                _context.Nominas.Remove(Nomina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
