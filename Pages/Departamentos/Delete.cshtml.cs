using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRManager.Data; 
using HRManager.Models; 

namespace HRManager.Pages.Departamentos 
{
    public class DeleteModel : PageModel
    {
        private readonly HRManagerContext _context; 

        public DeleteModel(HRManagerContext context) 
        {
            _context = context;
        }

        [BindProperty]
        public Departamento Departamento { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departamentos == null) 
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos.FirstOrDefaultAsync(m => m.IdDepartamento == id); 

            if (departamento == null)
            {
                return NotFound();
            }
            else
            {
                Departamento = departamento;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Departamentos == null) 
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos.FindAsync(id); 

            if (departamento != null)
            {
                Departamento = departamento;
                _context.Departamentos.Remove(Departamento); 
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
