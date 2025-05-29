using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; 
using System.Threading.Tasks; 

namespace HRManager.Pages.Empleados
{
    public class DeleteModel : PageModel
    {
        private readonly HRManagerContext _context;

        public DeleteModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

     
            Empleado = await _context.Empleados
                .Include(e => e.Cargo)
                .Include(e => e.Departamento)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);

            if (Empleado == null)
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

            Empleado = await _context.Empleados.FindAsync(id);

            if (Empleado != null)
            {
                _context.Empleados.Remove(Empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
