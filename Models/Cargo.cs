using System.ComponentModel.DataAnnotations;

namespace HRManager.Models
{
    public class Cargo
    {
        [Key]
        public int IdCargo { get; set; }

       
        public string TituloCargo { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Empleado>? Empleados { get; set; }
    }
}
