// HRManager/Pages/Empleados/Create.cshtml.cs
using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // Necesario para SelectList
using System.Threading.Tasks;

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
            // Cargar la lista de Cargos para el dropdown
            CargoTitulo = new SelectList(_context.Cargos, "IdCargo", "TituloCargo");

            // Cargar la lista de Departamentos para el dropdown
            DepartamentoNombre = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // La validación que viene de tu template SupermarketWEB
            if (!ModelState.IsValid || _context.Empleados == null || Empleado == null)
            {
                // Si la validación falla, recargar las listas de dropdowns
                // para que sigan apareciendo si la página se vuelve a mostrar
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
