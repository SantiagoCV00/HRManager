using HRManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManager.Models;

namespace HRManager.Pages.Departamentos
{
    public class CreateModel : PageModel
    {
        private readonly HRManagerContext _context;

        public CreateModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Departamento Departamento { get; set; } = default!;

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

            _context.Departamentos.Add(Departamento);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
