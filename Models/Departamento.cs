using System.ComponentModel.DataAnnotations;

namespace HRManager.Models
{
    public class Departamento
    {
        
            [Key]
            public int IdDepartamento { get; set; }

            [Required]
            public string NombreDepartamento { get; set; }

            public string Ubicacion { get; set; }

            public ICollection<Empleado> Empleados { get; set; }
        
    }
}
