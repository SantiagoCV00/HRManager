using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Nominas
{
    public class IndexModel : PageModel
    {
        private readonly HRManagerContext _context;

        public IndexModel(HRManagerContext context)
        {
            _context = context;
        }

        public IList<Nomina> Nominas { get; set; } = default!;

        public async Task OnGetAsync()
        {
            
            if (_context.Nominas != null)
            {
                Nominas = await _context.Nominas
                    .Include(n => n.Empleado)
                    .ToListAsync();
            }
        }
    }
}
