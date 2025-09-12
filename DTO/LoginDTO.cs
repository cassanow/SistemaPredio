using System.ComponentModel.DataAnnotations;

namespace SistemaPredio.DTO;

public class LoginDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MinLength(10)]
    [MaxLength(100)]
    public string Senha { get; set; }
}