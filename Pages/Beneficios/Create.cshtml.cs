using HRManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManager.Models;

namespace HRManager.Pages.Beneficios
{
    public class CreateModel : PageModel
    {
        private readonly HRManagerContext _context;

        public CreateModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Beneficio Beneficio { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Beneficios.Add(Beneficio);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
