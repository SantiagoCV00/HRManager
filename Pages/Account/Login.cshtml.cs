using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManager.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using HRManager.Data; 
using Microsoft.EntityFrameworkCore; 

namespace HRManager.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly HRManagerContext _context; 

        public LoginModel(HRManagerContext context) 
        {
            _context = context;
        }

        [BindProperty]
        public User Input { get; set; } = new User(); 

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
                ErrorMessage = "Por favor, ingresa tu correo y contraseña."; 
                return Page();
            }

            var userInDb = await _context.Users
                                        .FirstOrDefaultAsync(u => u.Email == Input.Email);

            if (userInDb == null)
            {
                ErrorMessage = "Credenciales inválidas."; 
                return Page();
            }

  
            if (userInDb.Password != Input.Password) 
            {
                ErrorMessage = "Credenciales inválidas."; 
                return Page();
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userInDb.Email),
                new Claim(ClaimTypes.Email, userInDb.Email),

            };

            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

      
            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

            SuccessMessage = "¡Bienvenido!"; 
            return RedirectToPage("/Index"); 
        }
    }
}
