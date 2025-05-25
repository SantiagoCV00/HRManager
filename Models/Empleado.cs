using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; }

        // FK
        public int IdDepartamento { get; set; }
        public Departamento Departamento { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salario { get; set; }

        // FK
        public int IdCargo { get; set; }
        public Cargo Cargo { get; set; }
    }
}
