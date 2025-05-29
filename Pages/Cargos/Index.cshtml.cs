using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Cargos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HRManagerContext _context;

        public IndexModel(HRManagerContext context)
        {
            _context = context;
        }

        public IList<Cargo> Cargos { get; set; }

        public async Task OnGetAsync()
        {
            Cargos = await _context.Cargos
                .Include(c => c.Empleados) // Incluye la relación con Empleados
                .AsNoTracking() // Mejora rendimiento para operaciones de solo lectura
                .ToListAsync();
        }
    }
}