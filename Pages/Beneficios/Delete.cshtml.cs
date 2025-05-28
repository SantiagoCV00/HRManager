using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManager.Pages.Beneficios
{
    public class DeleteModel : PageModel
    {
        private readonly HRManagerContext _context;

        public DeleteModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Beneficio Beneficio { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Beneficio = await _context.Beneficios.FindAsync(id);

            if ( Beneficio == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var beneficio = await _context.Beneficios.FindAsync(Beneficio.IdBeneficio);

            if (beneficio != null)
            {
                _context.Beneficios.Remove(beneficio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }

    }
}
