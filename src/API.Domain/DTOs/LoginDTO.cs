using System.ComponentModel.DataAnnotations;

namespace API.Domain.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email é campo obrigatório para Login")]
        [EmailAddress(ErrorMessage = "Email informado é inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres")]
        public string email { get; set; }
    }
}
