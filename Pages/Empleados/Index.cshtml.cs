using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; // Necesario para IList
using System.Threading.Tasks; // Necesario para Task

namespace HRManager.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly HRManagerContext _context;

        public IndexModel(HRManagerContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleados { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Incluimos las propiedades de navegación 'Cargo' y 'Departamento'
            // para poder acceder a sus datos (TituloCargo, NombreDepartamento) en la vista.
            if (_context.Empleados != null)
            {
                Empleados = await _context.Empleados
                    .Include(e => e.Cargo)
                    .Include(e => e.Departamento)
                    .ToListAsync();
            }
        }
    }
}
