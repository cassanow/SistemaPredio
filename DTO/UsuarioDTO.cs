using System.ComponentModel.DataAnnotations;

namespace SistemaPredio.DTO;

public class UsuarioDTO
{
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string CPF { get; set; }
    
    [Required]
    [MinLength(10)]
    [MaxLength(100)]
    public string Senha { get; set; }
}