using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; 
using HRManager.Data;
using HRManager.Models;

namespace HRManager.Pages.Nominas
{
    public class IndexModel : PageModel
    {
        private readonly HRManagerContext _context;

        public IndexModel(HRManagerContext context)
        {
            _context = context;
        }

        public IList<Nomina> Nomina { get; set; } = default!; 

        public async Task OnGetAsync()
        {
            if (_context.Nominas != null)
            {
                Nomina = await _context.Nominas
                    .Include(n => n.Empleado) 
                    .ToListAsync();
            }
        }
    }
}
