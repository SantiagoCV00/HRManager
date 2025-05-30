using Microsoft.EntityFrameworkCore;
using HRManager.Models;

namespace HRManager.Data
{
    public class HRManagerContext : DbContext
    {
        public HRManagerContext(DbContextOptions<HRManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Beneficio> Beneficios { get; set; }
        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<User> Users { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Departamento)
                .WithMany(d => d.Empleados)
                .HasForeignKey(e => e.IdDepartamento)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Cargo)
                .WithMany(c => c.Empleados)
                .HasForeignKey(e => e.IdCargo)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Nomina>()
                .HasOne(n => n.Empleado)
                .WithMany()
                .HasForeignKey(n => n.IdEmpleado)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}