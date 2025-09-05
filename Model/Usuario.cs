using System.ComponentModel.DataAnnotations;
using SistemaPredio.Enum;

namespace SistemaPredio.Model;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string CPF { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Senha { get; set; }
    
    public Role Role { get; set; }
}