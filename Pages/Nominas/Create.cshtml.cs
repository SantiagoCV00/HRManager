using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; 
using System.Threading.Tasks;

namespace HRManager.Pages.Nominas
{
    public class CreateModel : PageModel
    {
        private readonly HRManagerContext _context;

        public CreateModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nomina Nomina { get; set; } = new Nomina(); 

        public SelectList EmpleadoList { get; set; } = default!; 

        public IActionResult OnGet()
        {
       
            EmpleadoList = new SelectList(_context.Empleados, "IdEmpleado", "Nombre"); 

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Nominas == null || Nomina == null)
            {
                
                EmpleadoList = new SelectList(_context.Empleados, "IdEmpleado", "Nombre"); 
                return Page();
            }

            _context.Nominas.Add(Nomina);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
