using System.ComponentModel.DataAnnotations;
using SistemaPredio.Enum;

namespace SistemaPredio.Model;

public class Usuario
{
    [Key]
    [StringLength(10, MinimumLength = 10)]
    public int Id { get; set; }
    
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
    
    public Role Role { get; set; }
}