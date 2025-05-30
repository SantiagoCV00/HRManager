using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRManager.Data;
using HRManager.Models;

namespace HRManager.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly HRManagerContext _context;

        public IndexModel(HRManagerContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleado { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Empleados != null)
            {

                Empleado = await _context.Empleados
                    .Include(e => e.Cargo)
                    .Include(e => e.Departamento)
                    .ToListAsync();
            }
        }
    }
}