using System.ComponentModel.DataAnnotations;

namespace HRManager.Models
{
    public class Departamento
    {
        
            [Key]
            public int IdDepartamento { get; set; }

            [Required]
            [Display(Name = "Nombre del Departamento")]
            public string NombreDepartamento { get; set; }
           
            [Required]
            [Display(Name = "Ubicación")]
            public string Ubicacion { get; set; }

            public ICollection<Empleado>? Empleados { get; set; }
        
    }
}
