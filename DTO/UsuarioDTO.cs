using System.ComponentModel.DataAnnotations;

namespace SistemaPredio.DTO;

public class UsuarioDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string CPF { get; set; }
    
    [Required]
    [MinLength(10)]
    [MaxLength(100)]
    public string Senha { get; set; }
}