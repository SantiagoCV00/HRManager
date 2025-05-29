using System.ComponentModel.DataAnnotations; 

namespace HRManager.Models
{
    public class User
    {
        [Key] 
        public int Id { get; set; } 

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Formato de correo electrónico inválido.")]
        public string? Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres y un máximo de {1}.", MinimumLength = 6)]
        public string? Password { get; set; } = string.Empty;
    }
}
