using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Para [ForeignKey]

namespace HRManager.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty; // Inicializar para evitar warnings
        [Required]
        public string Apellido { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string Telefono { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; }

        // FK a Departamento
        [ForeignKey("IdDepartamento")] // <--- ¡Añade esto!
        public int IdDepartamento { get; set; }
        public Departamento? Departamento { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }

        // FK a Cargo
        [ForeignKey("IdCargo")] // <--- ¡Añade esto!
        public int IdCargo { get; set; }
        public Cargo? Cargo { get; set; }
    }
}