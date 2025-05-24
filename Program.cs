

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using HRManager.Data;
    using global::HRManager.Data;

    namespace HRManager
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

                // Agrega soporte para Razor Pages
                builder.Services.AddRazorPages();

                // ✅ Configuración de autenticación con cookies
                builder.Services.AddAuthentication()
                    .AddCookie("MyCookieAuth", options =>
                    {
                        options.Cookie.Name = "MyCookieAuth";
                        options.LoginPath = "/Account/Login"; // Redirección al login si no está autenticado
                    });

                // ✅ Registro del contexto de base de datos
                builder.Services.AddDbContext<HRManagerContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("HRManagerDB"))
                );

                var app = builder.Build();

                // Configuración del middleware HTTP
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Error");
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                // ✅ Activar autenticación y autorización
                app.UseAuthentication();
                app.UseAuthorization();

                app.MapRazorPages();

                app.Run();
            }
        }
    }
