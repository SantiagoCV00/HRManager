using System.ComponentModel.DataAnnotations;

namespace HRManager.Models
{
    public class Nomina
    {
        [Key]
        public int IdNomina { get; set; }

        [Required]
        public int? IdEmpleado { get; set; }
        public Empleado? Empleado { get; set; }

        [DataType(DataType.Date)]
        public DateTime PeriodoInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime PeriodoFin { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalPagado { get; set; }
    }
}
