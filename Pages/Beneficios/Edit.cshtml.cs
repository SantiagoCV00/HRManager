using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Beneficios
{
    public class EditModel : PageModel
    {
        private readonly HRManagerContext _context;

        public EditModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Beneficio Beneficio { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Beneficio = await _context.Beneficios.FindAsync(id);

            if (Beneficio == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Beneficio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Beneficios.Any(e => e.IdBeneficio == Beneficio.IdBeneficio))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("Index");
        }
    }
}
