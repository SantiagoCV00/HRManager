using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HRManager.Pages.Empleados
{
    public class EditModel : PageModel
    {
        private readonly HRManagerContext _context;

        public EditModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = default!;


        public SelectList CargoTitulo { get; set; } = default!;
        public SelectList DepartamentoNombre { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.Cargo)
                .Include(e => e.Departamento)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);

            if (empleado == null)
            {
                return NotFound();
            }
            Empleado = empleado;


            CargoTitulo = new SelectList(_context.Cargos, "IdCargo", "TituloCargo");
            DepartamentoNombre = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                CargoTitulo = new SelectList(_context.Cargos, "IdCargo", "TituloCargo", Empleado.IdCargo);
                DepartamentoNombre = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento", Empleado.IdDepartamento);
                return Page();
            }

            _context.Attach(Empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(Empleado.IdEmpleado))
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

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}