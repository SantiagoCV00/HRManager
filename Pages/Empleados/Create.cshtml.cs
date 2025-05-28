using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // Necesario para SelectList
using System.Threading.Tasks; // Necesario para Task

namespace HRManager.Pages.Empleados
{
    public class CreateModel : PageModel
    {
        private readonly HRManagerContext _context;

        public CreateModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = new Empleado();

        
        public SelectList CargoTitulo { get; set; } = default!;
        public SelectList DepartamentoNombre { get; set; } = default!;

        public IActionResult OnGet()
        {
            
            CargoTitulo = new SelectList(_context.Cargos, "IdCargo", "TituloCargo");

           
            DepartamentoNombre = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                
                CargoTitulo = new SelectList(_context.Cargos, "IdCargo", "TituloCargo");
                DepartamentoNombre = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento");
                return Page();
            }

            _context.Empleados.Add(Empleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
