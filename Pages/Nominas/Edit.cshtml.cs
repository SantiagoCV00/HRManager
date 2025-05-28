using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HRManager.Pages.Nominas
{
    public class EditModel : PageModel
    {
        private readonly HRManagerContext _context;

        public EditModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nomina Nomina { get; set; } = default!;

        public SelectList EmpleadoNombreApellido { get; set; } = default!;

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

           
            EmpleadoNombreApellido = new SelectList(_context.Empleados, "IdEmpleado", "Nombre", Nomina.IdEmpleado);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
        
                EmpleadoNombreApellido = new SelectList(_context.Empleados, "IdEmpleado", "Nombre", Nomina.IdEmpleado);
                return Page();
            }

            _context.Attach(Nomina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NominaExists(Nomina.IdNomina))
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

        private bool NominaExists(int id)
        {
            return _context.Nominas.Any(e => e.IdNomina == id);
        }
    }
}
