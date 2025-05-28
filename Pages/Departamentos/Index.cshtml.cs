using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Departamentos
{
    public class IndexModel : PageModel
    {
        private readonly HRManagerContext _context;

        public IndexModel(HRManagerContext context)
        {
            _context = context;
        }

        public IList<Departamento> Departamentos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Departamentos = await _context.Departamentos.ToListAsync();
        }
    }
}
