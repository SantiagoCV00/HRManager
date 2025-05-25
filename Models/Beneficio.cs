using System.ComponentModel.DataAnnotations;

namespace HRManager.Models
{
    public class Beneficio
    {
        [Key]
        public int IdBeneficio { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [DataType(DataType.Currency)]
        public decimal CostoEmpresa { get; set; }

        [DataType(DataType.Currency)]
        public decimal CostoEmpleado { get; set; }
    }
}
