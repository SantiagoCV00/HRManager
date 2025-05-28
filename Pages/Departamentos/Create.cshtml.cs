using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManager.Data; 
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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Departamento Departamento { get; set; } = default!; 

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Departamentos == null || Departamento == null) 
            {
                return Page();
            }

            _context.Departamentos.Add(Departamento); 
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
