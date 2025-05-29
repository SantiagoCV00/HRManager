using HRManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; 
using HRManager.Data; 

namespace HRManager.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly HRManagerContext _context;

        public RegisterModel(HRManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User RegisterData { get; set; } = new User(); 

        [TempData]
        public string SuccessMessage { get; set; } = string.Empty;
        [TempData]
        public string ErrorMessage { get; set; } = string.Empty;

        public void OnGet()
        {

            if (TempData.ContainsKey("SuccessMessage"))
            {
                SuccessMessage = TempData["SuccessMessage"] as string ?? string.Empty;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
    
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == RegisterData.Email);

            if (existingUser != null)
            {
    
                ModelState.AddModelError("RegisterData.Email", "Este correo electrónico ya está registrado.");
                ErrorMessage = "Error de registro: Este correo electrónico ya está registrado.";
                return Page();
            }

      
            var newUser = new User
            {
                Email = RegisterData.Email,
                Password = RegisterData.Password 
            };

            _context.Users.Add(newUser); 
            await _context.SaveChangesAsync(); 

            SuccessMessage = "Registro exitoso. Ahora puedes iniciar sesión.";
        
            TempData["SuccessMessage"] = SuccessMessage; 
            return RedirectToPage("/Account/Login");
        }
    }
}
